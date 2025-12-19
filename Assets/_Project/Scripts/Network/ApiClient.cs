using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;

namespace TapLive.Network
{
    /// <summary>
    /// REST API client using UnityWebRequest
    /// Handles authentication and order fetching
    /// </summary>
    public class ApiClient : MonoBehaviour
    {
        private string _baseUrl = "https://api.example.com";
        
        public void SetBaseUrl(string url)
        {
            _baseUrl = url;
            Debug.Log($"[ApiClient] Base URL set to: {_baseUrl}");
        }

        /// <summary>
        /// Fetch orders from API
        /// </summary>
        public void FetchOrders(Action<string> onSuccess, Action<string> onError)
        {
            StartCoroutine(FetchOrdersCoroutine(onSuccess, onError));
        }

        private IEnumerator FetchOrdersCoroutine(Action<string> onSuccess, Action<string> onError)
        {
            string endpoint = $"{_baseUrl}/api/orders";
            
            using (UnityWebRequest request = UnityWebRequest.Get(endpoint))
            {
                // Add headers (e.g., authentication)
                request.SetRequestHeader("Content-Type", "application/json");
                // TODO: Add auth token
                // request.SetRequestHeader("Authorization", $"Bearer {authToken}");
                
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("[ApiClient] Orders fetched successfully.");
                    onSuccess?.Invoke(request.downloadHandler.text);
                }
                else
                {
                    Debug.LogError($"[ApiClient] Error fetching orders: {request.error}");
                    onError?.Invoke(request.error);
                }
            }
        }

        /// <summary>
        /// Generic GET request
        /// </summary>
        public void Get(string endpoint, Action<string> onSuccess, Action<string> onError)
        {
            StartCoroutine(GetCoroutine(endpoint, onSuccess, onError));
        }

        private IEnumerator GetCoroutine(string endpoint, Action<string> onSuccess, Action<string> onError)
        {
            string url = $"{_baseUrl}{endpoint}";
            
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                request.SetRequestHeader("Content-Type", "application/json");
                
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    onSuccess?.Invoke(request.downloadHandler.text);
                }
                else
                {
                    onError?.Invoke(request.error);
                }
            }
        }

        /// <summary>
        /// Generic POST request
        /// </summary>
        public void Post(string endpoint, string jsonData, Action<string> onSuccess, Action<string> onError)
        {
            StartCoroutine(PostCoroutine(endpoint, jsonData, onSuccess, onError));
        }

        private IEnumerator PostCoroutine(string endpoint, string jsonData, Action<string> onSuccess, Action<string> onError)
        {
            string url = $"{_baseUrl}{endpoint}";
            
            using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
            {
                byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");
                
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    onSuccess?.Invoke(request.downloadHandler.text);
                }
                else
                {
                    onError?.Invoke(request.error);
                }
            }
        }
    }
}
