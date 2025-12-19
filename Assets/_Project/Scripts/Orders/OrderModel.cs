using UnityEngine;
using System;
using System.Collections.Generic;

namespace TapLive.Orders
{
    /// <summary>
    /// Data model for orders
    /// Serializable for JSON parsing
    /// </summary>
    [Serializable]
    public class OrderModel
    {
        public string orderId;
        public string customerId;
        public string customerName;
        public string productName;
        public int quantity;
        public float price;
        public string status; // "pending", "processing", "completed", "cancelled"
        public long timestamp;
        
        // XR-specific data
        public Vector3 displayPosition;
        public string videoUrl;
        public string thumbnailUrl;

        public OrderModel()
        {
            orderId = Guid.NewGuid().ToString();
            status = "pending";
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        public override string ToString()
        {
            return $"Order [{orderId}] {productName} x{quantity} - {status}";
        }
    }

    /// <summary>
    /// Container for multiple orders (for JSON deserialization)
    /// </summary>
    [Serializable]
    public class OrdersContainer
    {
        public List<OrderModel> orders;
    }
}
