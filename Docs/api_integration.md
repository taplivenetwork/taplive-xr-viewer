# API Integration Guide

## Overview
The TapLive XR application uses a REST API for order management and WebSocket for real-time updates.

## Configuration

### 1. Update app_config.json
Edit `Assets/StreamingAssets/app_config.json`:

```json
{
  "apiBaseUrl": "https://your-api-server.com",
  "webSocketUrl": "wss://your-socket-server.com",
  "enableDebugMode": true
}
```

### 2. API Authentication
Update `ApiClient.cs` to include your authentication:

```csharp
// In FetchOrdersCoroutine method, uncomment and modify:
request.SetRequestHeader("Authorization", $"Bearer {yourAuthToken}");
```

---

## API Endpoints

### Fetch Orders
**Endpoint**: `GET /api/orders`

**Response**:
```json
{
  "orders": [
    {
      "orderId": "ORD-001",
      "customerId": "CUST-123",
      "customerName": "John Doe",
      "productName": "VR Headset",
      "quantity": 2,
      "price": 599.99,
      "status": "pending",
      "timestamp": 1733689200,
      "videoUrl": "https://cdn.example.com/video.mp4"
    }
  ]
}
```

### Update Order Status
**Endpoint**: `POST /api/orders/{orderId}/status`

**Request Body**:
```json
{
  "status": "processing"
}
```

---

## WebSocket Integration

### 1. Install WebSocket Library
The project uses a stub `SocketClient`. To enable real WebSocket:

**Option A: NativeWebSocket (Recommended for WebGL)**
```
Add package: com.endel.nativewebsocket
```

**Option B: WebSocketSharp (Desktop/Mobile)**
Download from [NuGet](https://www.nuget.org/packages/WebSocketSharp) and add DLL to `Assets/Plugins/`

### 2. Update SocketClient.cs
After installing library, uncomment the TODO sections:

```csharp
using WebSocketSharp; // or NativeWebSocket

private WebSocket _socket;

public void Connect(string url)
{
    _socket = new WebSocket(url);
    _socket.OnOpen += OnSocketOpen;
    _socket.OnMessage += (sender, e) => OnSocketMessage(e.Data);
    _socket.Connect();
}
```

### 3. WebSocket Events
Handle real-time order updates:

```csharp
private void OnSocketMessage(string message)
{
    var update = JsonUtility.FromJson<OrderUpdate>(message);
    // Refresh orders display
    orderRoomBinder.RefreshOrders();
}
```

---

## Testing with Mock Data

### 1. Enable Mock Mode
In `OrderLoader` component:
- Check **Use Mock Data**
- Set **Mock Data File Name**: `mock_orders.json`

### 2. Modify Mock Data
Edit `Assets/StreamingAssets/mock_orders.json` to test different scenarios.

---

## WebRTC Integration

### 1. Install Unity WebRTC Package
```
Package Manager > Add package from git URL
com.unity.webrtc
```

### 2. Configure WebRTCClient
Update `WebRTCClient.cs` after package installation (see TODO comments).

### 3. Signaling Server
WebRTC requires a signaling server to exchange SDP and ICE candidates. Implement using:
- Socket.io server
- Firebase Realtime Database
- Custom REST API

---

## Security Considerations
- **HTTPS/WSS**: Always use secure connections in production
- **API Keys**: Store in secure backend, not in client
- **Rate Limiting**: Implement on server side
- **Input Validation**: Validate all data from API

## Next Steps
- Test API connection in Debug mode
- Proceed to [Build for Meta Quest](build_meta_quest.md)
