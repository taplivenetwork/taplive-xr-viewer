# Build for Meta Quest Guide

## Overview
This guide covers building and deploying the TapLive XR application to Meta Quest devices (Quest 2, Quest 3, Quest Pro).

## Prerequisites
- Meta Quest device
- Meta account
- USB-C cable (for Quest Link or direct deployment)
- Android Build Support installed in Unity

---

## Part 1: Device Setup

### 1. Enable Developer Mode
1. Install **Meta Quest Developer Hub** or **Meta Quest Mobile App**
2. In the mobile app:
   - Go to **Menu > Devices**
   - Select your headset
   - Go to **Developer Mode**
   - Toggle **Developer Mode** ON
3. Accept developer agreement

### 2. Enable USB Debugging
1. Put on your Quest headset
2. Connect to PC via USB-C
3. Allow USB debugging prompt will appear
4. Check **Always allow** and click **OK**

### 3. Verify Connection
Run in command prompt:
```bash
adb devices
```
You should see your Quest listed.

---

## Part 2: Unity Build Configuration

### 1. Switch to Android Platform
1. **File > Build Settings**
2. Select **Android**
3. Click **Switch Platform** (wait for reimport)

### 2. Player Settings
Go to **Edit > Project Settings > Player**

#### Android Settings Tab
**Other Settings**:
- **Graphics APIs**: Remove OpenGLES3, keep **Vulkan** only
- **Color Space**: Linear
- **Auto Graphics API**: Uncheck
- **Minimum API Level**: Android 10.0 (API Level 29)
- **Target API Level**: Android 13.0 (API Level 33) or latest

**Identification**:
- **Package Name**: `com.taplive.xrviewer` (change as needed)
- **Version**: `1.0.0`
- **Bundle Version Code**: `1`

**Configuration**:
- **Scripting Backend**: **IL2CPP**
- **Target Architectures**: Check **ARM64** (uncheck ARMv7)

### 3. Quality Settings
**Edit > Project Settings > Quality**:
- Set **Default** quality level to Medium or High
- Disable Anti-Aliasing for better performance
- Set **Pixel Light Count**: 1

### 4. XR Settings
**Edit > Project Settings > XR Plug-in Management**:
- Select **Android** tab
- Check **OpenXR**
- Under **OpenXR**:
  - **Render Mode**: Single Pass Instanced
  - **Depth Submission Mode**: Depth 24 Bit

---

## Part 3: Build & Deploy

### Method 1: Build and Run (Recommended)
1. Connect Quest via USB
2. **File > Build Settings**
3. Check **Development Build** (for debugging)
4. Click **Build And Run**
5. Choose save location for APK
6. Wait for build and automatic installation

### Method 2: Manual APK Install
1. **File > Build Settings**
2. Click **Build**
3. Save APK (e.g., `taplive-xr.apk`)
4. Install via command:
```bash
adb install -r path/to/taplive-xr.apk
```

### Method 3: SideQuest
1. Download [SideQuest](https://sidequestvr.com/)
2. Connect Quest
3. Drag APK into SideQuest
4. Click Install

---

## Part 4: Testing & Debugging

### Launch App
1. In Quest, open **App Library**
2. Filter by **Unknown Sources** (top-right dropdown)
3. Find and launch **TapLiveXR**

### View Logs
On PC, run:
```bash
adb logcat -s Unity
```

### Performance Profiling
1. Enable **Development Build** and **Autoconnect Profiler**
2. In Unity: **Window > Analysis > Profiler**
3. Launch app on Quest
4. Monitor FPS, memory, rendering

---

## Optimization Tips

### Performance
- **Target FPS**: 72 Hz (Quest 2) or 90 Hz (Quest 3)
- Use **Oculus OVR Metrics Tool** for performance overlay
- Reduce draw calls: combine meshes, use atlasing
- Use **LOD (Level of Detail)** for complex models

### Video Playback
- **Codec**: H.264 or H.265 (HEVC)
- **Resolution**: Max 5.7K for 360° video
- **Bitrate**: 50-100 Mbps for high quality
- Test streaming vs. local playback performance

### Battery Life
- Reduce resolution if targeting longer sessions
- Implement power-saving mode for idle states

---

## Common Issues

### "Application installation failed"
- Check USB debugging is enabled
- Try different USB port/cable
- Restart ADB: `adb kill-server` then `adb start-server`

### Black screen on launch
- Verify video codec compatibility
- Check XR Plug-in Management settings
- Ensure Vulkan is the graphics API

### Controller input not working
- Verify Oculus Touch Profile is added in OpenXR
- Check Input Actions are properly configured

---

## Distribution

### Meta Quest Store
1. Create developer account at [Meta for Developers](https://developer.oculus.com/)
2. Submit app for review
3. Follow [Oculus Publishing Guide](https://developer.oculus.com/distribute/)

### SideQuest/App Lab
Alternative distribution for beta testing and indie apps.

## Next Steps
- Test all features on device
- Profile performance
- Submit for app review
