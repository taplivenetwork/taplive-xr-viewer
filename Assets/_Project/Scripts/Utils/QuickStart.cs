using UnityEngine;

namespace TapLive.Utils
{
    /// <summary>
    /// Quick start helper - attach to any GameObject to test basic functionality
    /// </summary>
    public class QuickStart : MonoBehaviour
    {
        [Header("Quick Test Settings")]
        public bool initializeOnStart = true;
        public bool testOrderLoading = true;
        public bool testNetworkClients = false;

        private void Start()
        {
            if (!initializeOnStart) return;

            Debug.Log("=== TapLive XR Quick Start ===");
            
            // Test AppManager
            TestAppManager();
            
            if (testOrderLoading)
            {
                TestOrderSystem();
            }
            
            if (testNetworkClients)
            {
                TestNetwork();
            }
        }

        private void TestAppManager()
        {
            var appManager = Core.AppManager.Instance;
            if (appManager != null)
            {
                Debug.Log("✓ AppManager loaded");
                var config = appManager.GetConfig();
                Debug.Log($"  API: {config.apiBaseUrl}");
                Debug.Log($"  Debug Mode: {config.enableDebugMode}");
            }
            else
            {
                Debug.LogWarning("✗ AppManager not found. Create Bootstrap scene or add AppManager to scene.");
            }
        }

        private void TestOrderSystem()
        {
            var orderLoader = FindObjectOfType<Orders.OrderLoader>();
            if (orderLoader != null)
            {
                Debug.Log("✓ OrderLoader found, loading orders...");
                orderLoader.LoadOrders((orders) =>
                {
                    Debug.Log($"✓ Loaded {orders.Count} orders:");
                    foreach (var order in orders)
                    {
                        Debug.Log($"  - {order}");
                    }
                });
            }
            else
            {
                Debug.LogWarning("✗ OrderLoader not found in scene.");
            }
        }

        private void TestNetwork()
        {
            var networkManager = Core.NetworkManager.Instance;
            if (networkManager != null)
            {
                Debug.Log("✓ NetworkManager found");
                var apiClient = networkManager.GetApiClient();
                Debug.Log($"  API Client: {(apiClient != null ? "Ready" : "Not initialized")}");
            }
        }
    }
}
