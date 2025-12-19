using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace TapLive.Orders
{
    /// <summary>
    /// Loads orders from API or mock JSON file
    /// </summary>
    public class OrderLoader : MonoBehaviour
    {
        [Header("Settings")]
        public bool useMockData = true;
        public string mockDataFileName = "mock_orders.json";

        private List<OrderModel> _loadedOrders;

        public void LoadOrders(System.Action<List<OrderModel>> onComplete)
        {
            if (useMockData)
            {
                LoadMockOrders(onComplete);
            }
            else
            {
                LoadFromAPI(onComplete);
            }
        }

        private void LoadMockOrders(System.Action<List<OrderModel>> onComplete)
        {
            string path = Path.Combine(Application.streamingAssetsPath, mockDataFileName);
            
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                OrdersContainer container = JsonUtility.FromJson<OrdersContainer>(json);
                
                _loadedOrders = container.orders;
                Debug.Log($"[OrderLoader] Loaded {_loadedOrders.Count} mock orders.");
                
                onComplete?.Invoke(_loadedOrders);
            }
            else
            {
                Debug.LogError($"[OrderLoader] Mock data file not found: {path}");
                _loadedOrders = new List<OrderModel>();
                onComplete?.Invoke(_loadedOrders);
            }
        }

        private void LoadFromAPI(System.Action<List<OrderModel>> onComplete)
        {
            Debug.Log("[OrderLoader] Loading orders from API...");
            
            var apiClient = Core.NetworkManager.Instance?.GetApiClient();
            
            if (apiClient != null)
            {
                apiClient.FetchOrders(
                    onSuccess: (json) => {
                        OrdersContainer container = JsonUtility.FromJson<OrdersContainer>(json);
                        _loadedOrders = container.orders;
                        Debug.Log($"[OrderLoader] Loaded {_loadedOrders.Count} orders from API.");
                        onComplete?.Invoke(_loadedOrders);
                    },
                    onError: (error) => {
                        Debug.LogError($"[OrderLoader] Failed to load orders: {error}");
                        _loadedOrders = new List<OrderModel>();
                        onComplete?.Invoke(_loadedOrders);
                    }
                );
            }
            else
            {
                Debug.LogError("[OrderLoader] NetworkManager or ApiClient not available.");
                onComplete?.Invoke(new List<OrderModel>());
            }
        }

        public List<OrderModel> GetLoadedOrders() => _loadedOrders;
    }
}
