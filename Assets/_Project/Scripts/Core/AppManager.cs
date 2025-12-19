using UnityEngine;
using System.IO;

namespace TapLive.Core
{
    /// <summary>
    /// Central application manager - handles initialization and lifecycle
    /// </summary>
    public class AppManager : MonoBehaviour
    {
        public static AppManager Instance { get; private set; }

        [Header("Configuration")]
        public bool loadConfigFromFile = true;
        
        private AppConfig _config;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            InitializeApp();
        }

        private void InitializeApp()
        {
            Debug.Log("[AppManager] Initializing application...");
            
            // Load configuration
            if (loadConfigFromFile)
            {
                LoadConfiguration();
            }
            
            // Initialize managers in order
            InitializeManagers();
            
            Debug.Log("[AppManager] Application initialized successfully.");
        }

        private void LoadConfiguration()
        {
            string configPath = Path.Combine(Application.streamingAssetsPath, "app_config.json");
            
            if (File.Exists(configPath))
            {
                string json = File.ReadAllText(configPath);
                _config = JsonUtility.FromJson<AppConfig>(json);
                Debug.Log($"[AppManager] Configuration loaded: API={_config.apiBaseUrl}, Debug={_config.enableDebugMode}");
            }
            else
            {
                Debug.LogWarning($"[AppManager] Config file not found at {configPath}, using defaults.");
                _config = new AppConfig();
            }
        }

        private void InitializeManagers()
        {
            // Initialize XR Manager
            if (XRManager.Instance == null)
            {
                gameObject.AddComponent<XRManager>();
            }
            
            // Initialize Network Manager
            if (NetworkManager.Instance == null)
            {
                gameObject.AddComponent<NetworkManager>();
            }
        }

        public AppConfig GetConfig() => _config;
    }

    [System.Serializable]
    public class AppConfig
    {
        public string apiBaseUrl = "https://api.example.com";
        public string webSocketUrl = "wss://socket.example.com";
        public bool enableDebugMode = true;
    }
}
