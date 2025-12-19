using UnityEngine;

namespace TapLive.Core
{
    /// <summary>
    /// Manages network connections (API, WebSocket, WebRTC)
    /// </summary>
    public class NetworkManager : MonoBehaviour
    {
        public static NetworkManager Instance { get; private set; }

        [Header("Network Clients")]
        public bool autoConnect = false;
        
        private Network.ApiClient _apiClient;
        private Network.SocketClient _socketClient;
        private Network.WebRTCClient _webRtcClient;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            
            Instance = this;
        }

        private void Start()
        {
            InitializeClients();
            
            if (autoConnect)
            {
                ConnectAll();
            }
        }

        private void InitializeClients()
        {
            Debug.Log("[NetworkManager] Initializing network clients...");
            
            // Initialize clients
            _apiClient = gameObject.AddComponent<Network.ApiClient>();
            _socketClient = gameObject.AddComponent<Network.SocketClient>();
            _webRtcClient = gameObject.AddComponent<Network.WebRTCClient>();
        }

        public void ConnectAll()
        {
            Debug.Log("[NetworkManager] Connecting all network clients...");
            
            var config = AppManager.Instance?.GetConfig();
            if (config != null)
            {
                _apiClient.SetBaseUrl(config.apiBaseUrl);
                _socketClient.Connect(config.webSocketUrl);
            }
        }

        public void DisconnectAll()
        {
            Debug.Log("[NetworkManager] Disconnecting all network clients...");
            _socketClient?.Disconnect();
        }

        public Network.ApiClient GetApiClient() => _apiClient;
        public Network.SocketClient GetSocketClient() => _socketClient;
        public Network.WebRTCClient GetWebRTCClient() => _webRtcClient;

        private void OnDestroy()
        {
            DisconnectAll();
        }
    }
}
