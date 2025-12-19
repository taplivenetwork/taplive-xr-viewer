# TapLive XR - Unity OpenXR Video Viewer Platform

A production-ready XR platform for immersive video viewing and order management, built with Unity and OpenXR.

## 🎯 Overview
TapLive XR is a comprehensive VR application that combines:
- **360°/180°/2D video playback** with full controller support
- **Real-time order management** with 3D spatial visualization  
- **Network integration** ready for API, WebSocket, and WebRTC
- **Scalable architecture** with proper namespacing and modularity

## 📁 Project Structure
```
Assets/
├── _Project/
│   ├── Scenes/              # Bootstrap, XRViewer, DebugRoom
│   ├── Scripts/
│   │   ├── Core/            # AppManager, XRManager, NetworkManager
│   │   ├── XR/              # Input, Camera Rig, UI Binder, Video
│   │   ├── Network/         # API, WebSocket, WebRTC clients
│   │   ├── Orders/          # Order models and management
│   │   ├── UI/              # HUD, Panels, Buttons
│   │   └── Utils/           # JSON, Logging utilities
│   ├── Prefabs/Materials/Models/Textures/Videos/Audio/
├── ThirdParty/              # External packages
└── StreamingAssets/         # Configuration files

Docs/                        # Comprehensive setup guides
```

## 🚀 Quick Start

### Prerequisites
- **Unity Hub** with Unity 6 (6000.0+) or Unity 2022.3 LTS minimum
- **Android Build Support** (for Quest) or **Windows Build Support** (for PCVR)
- **Meta Quest** headset or compatible OpenXR device

### Installation
1. **Clone the repository**
   ```bash
   git clone https://github.com/taplivenetwork/taplive-xr.git
   cd taplive-xr
   ```

2. **Follow the setup guides** (in order):
   - [Unity Setup](Docs/setup_unity.md)
   - [OpenXR Configuration](Docs/setup_openxr.md)
   - [Scene Setup](Docs/scene_setup.md)

3. **Test with mock data** before connecting to live APIs

## 📚 Documentation
Comprehensive guides in [`/Docs`](Docs/):
- **[setup_unity.md](Docs/setup_unity.md)** - Unity installation and project import
- **[setup_openxr.md](Docs/setup_openxr.md)** - OpenXR plugin configuration
- **[scene_setup.md](Docs/scene_setup.md)** - Scene creation walkthrough
- **[api_integration.md](Docs/api_integration.md)** - API/WebSocket/WebRTC integration
- **[build_meta_quest.md](Docs/build_meta_quest.md)** - Meta Quest deployment

## 🎮 Usage
- **Play/Pause**: Press Trigger or `A` button
- **Seek**: Use Joystick (Left/Right) or arrow keys (debug)
- **Menu**: Press `B` button or `Escape` (debug)

## 🔧 Configuration
Edit `Assets/StreamingAssets/app_config.json`:
```json
{
  "apiBaseUrl": "https://your-api.com",
  "webSocketUrl": "wss://your-socket.com",
  "enableDebugMode": true
}
```

## 🏗️ Architecture

### Core Systems
- **AppManager** - Central initialization and config loading
- **XRManager** - XR session lifecycle management
- **NetworkManager** - Coordinates all network clients

### Namespaces
- `TapLive.Core.*` - Core management systems
- `TapLive.XR.*` - XR interactions and video playback
- `TapLive.Network.*` - API, WebSocket, WebRTC clients
- `TapLive.Orders.*` - Order data and visualization
- `TapLive.UI.*` - HUD, panels, interactive buttons
- `TapLive.Utils.*` - JSON serialization, logging

## 🌐 Network Integration

### REST API
Functional `ApiClient` for orders and data fetching.

### WebSocket (Stub)
Requires external library:
- **NativeWebSocket** (WebGL) or **WebSocketSharp** (Desktop/Mobile)
- See [api_integration.md](Docs/api_integration.md) for setup

### WebRTC (Stub)
Requires Unity WebRTC package:
```
com.unity.webrtc
```

## 📦 Dependencies
- Unity 6 (6000.0+) recommended, or Unity 2022.3 LTS minimum
- OpenXR Plugin (`com.unity.xr.openxr`)
- XR Interaction Toolkit (recommended)
- TextMeshPro (for UI components)

## 🛡️ Governance & Security
- [CODE_OWNERS](CODEOWNERS) - Repository ownership
- [GOVERNANCE](GOVERNANCE.md) - Roles and decision-making
- [SECURITY](SECURITY.md) - Security policy and reporting
- [CONTRIBUTING](CONTRIBUTING.md) - Contribution guidelines
- [GEMINI_STRATEGY](GEMINI_STRATEGY.md) - AI integration strategy

## 📝 License
See [LICENSE](LICENSE) file for details.

## 🤝 Contributing
We welcome contributions! Please read [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

## 📧 Support
For issues or questions, please open a GitHub issue or contact the maintainers.

---

**Built with ❤️ by the TapLive Network team**


