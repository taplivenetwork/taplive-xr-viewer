# Scene Setup Guide

## Overview
This guide walks through creating the necessary scenes for the TapLive XR application.

## Scene Architecture
The project uses 3 main scenes:
1. **Bootstrap** - Initialization and app startup
2. **XRViewer** - Main XR experience with video playback
3. **DebugRoom** - Testing and debugging environment

---

## 1. Bootstrap Scene

### Purpose
Handles app initialization, config loading, and manager setup.

### Setup Steps
1. Create new scene: **File > New Scene > Basic (Built-in)**
2. Save as `Assets/_Project/Scenes/Bootstrap.unity`
3. Delete default **Main Camera** and **Directional Light**
4. Create empty GameObject: **Right-click Hierarchy > Create Empty**
5. Rename to `AppManager`
6. Add component: `TapLive.Core.AppManager`
7. Save scene

---

## 2. XRViewer Scene

### Purpose
Main XR experience with video playback and order visualization.

### Setup Steps

#### A. XR Origin
1. Create new scene: **File > New Scene > Basic (Built-in)**
2. Save as `Assets/_Project/Scenes/XRViewer.unity`
3. Delete default **Main Camera**
4. Right-click Hierarchy > **XR > XR Origin (Action-based)** or **XR > XR Origin (VR)**
5. Rename to `XR Origin`
6. Add component `XRCameraRig` to XR Origin

#### B. Video Sphere
1. Create **3D Object > Sphere**
2. Rename to `VideoSphere`
3. Set Transform:
   - Position: `(0, 0, 0)`
   - Scale: `(-100, 100, 100)` *(negative X for inverted normals)*
4. Remove **Sphere Collider** component
5. Add **Video Player** component:
   - Source: **URL** or **Video Clip**
   - Render Mode: **Material Override**
   - Target Material Property: `_BaseMap` (URP) or `_MainTex` (Built-in)
6. Create Material:
   - Right-click Project > **Create > Material**
   - Name: `VideoMaterial`
   - Shader: **Universal Render Pipeline/Unlit** or **Unlit/Texture**
7. Assign `VideoMaterial` to VideoSphere
8. Add component `VideoController` to VideoSphere

#### C. XR Input Handler
1. Select **XR Origin**
2. Add component `XRInputHandler`
3. In Inspector, assign:
   - **Video Controller**: Drag `VideoSphere` GameObject
   - **Input Actions**: Assign from XRI Default Input Actions

#### D. Order System
1. Create empty GameObject: `OrderSystem`
2. Add components:
   - `OrderLoader`
   - `OrderRoomBinder`
3. Configure `OrderLoader`:
   - Check **Use Mock Data**
4. Save scene

---

## 3. DebugRoom Scene

### Purpose
Simplified testing environment without full XR setup.

### Setup Steps
1. Create new scene: **File > New Scene > Basic (Built-in)**
2. Save as `Assets/_Project/Scenes/DebugRoom.unity`
3. Keep default **Main Camera**
4. Add **Video Player** to Main Camera (for quick testing)
5. Create UI Canvas for debug controls
6. Save scene

---

## Build Settings
1. Go to **File > Build Settings**
2. Add scenes in order:
   - `Bootstrap.unity` (index 0)
   - `XRViewer.unity` (index 1)
   - `DebugRoom.unity` (index 2)
3. Set **Platform** to **Android** or **Windows, Mac & Linux Standalone**
4. Click **Switch Platform**

## Next Steps
- Proceed to [API Integration Guide](api_integration.md)
- Or jump to [Build for Meta Quest](build_meta_quest.md)
