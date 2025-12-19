using UnityEngine;
using System.Collections.Generic;

namespace TapLive.Orders
{
    /// <summary>
    /// Binds order data to XR room/UI elements
    /// Manages visual representation of orders in 3D space
    /// </summary>
    public class OrderRoomBinder : MonoBehaviour
    {
        [Header("Prefabs")]
        public GameObject orderPanelPrefab;
        
        [Header("Layout Settings")]
        public float panelSpacing = 1.5f;
        public int panelsPerRow = 3;
        public Vector3 startPosition = new Vector3(-2f, 1.5f, 3f);

        private List<OrderModel> _currentOrders;
        private List<GameObject> _spawnedPanels = new List<GameObject>();

        public void BindOrders(List<OrderModel> orders)
        {
            Debug.Log($"[OrderRoomBinder] Binding {orders.Count} orders to room...");
            
            _currentOrders = orders;
            
            // Clear existing panels
            ClearPanels();
            
            // Spawn new panels
            for (int i = 0; i < orders.Count; i++)
            {
                SpawnOrderPanel(orders[i], i);
            }
        }

        private void SpawnOrderPanel(OrderModel order, int index)
        {
            if (orderPanelPrefab == null)
            {
                Debug.LogWarning("[OrderRoomBinder] Order panel prefab not assigned!");
                return;
            }

            // Calculate position in grid layout
            int row = index / panelsPerRow;
            int col = index % panelsPerRow;
            
            Vector3 position = startPosition + new Vector3(
                col * panelSpacing,
                -row * panelSpacing,
                0
            );

            // Instantiate panel
            GameObject panel = Instantiate(orderPanelPrefab, position, Quaternion.identity, transform);
            panel.name = $"OrderPanel_{order.orderId}";
            
            // TODO: Set panel data
            // var panelUI = panel.GetComponent<UI.XRPanel>();
            // if (panelUI != null)
            // {
            //     panelUI.SetOrderData(order);
            // }
            
            _spawnedPanels.Add(panel);
            
            Debug.Log($"[OrderRoomBinder] Spawned panel for order: {order}");
        }

        private void ClearPanels()
        {
            foreach (var panel in _spawnedPanels)
            {
                if (panel != null)
                {
                    Destroy(panel);
                }
            }
            
            _spawnedPanels.Clear();
        }

        public void RefreshOrders()
        {
            var loader = GetComponent<OrderLoader>();
            if (loader != null)
            {
                loader.LoadOrders(BindOrders);
            }
        }
    }
}
