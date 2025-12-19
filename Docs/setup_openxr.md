# OpenXR Setup Guide

## Overview
OpenXR is the industry-standard API for XR applications, providing cross-platform support for VR/AR devices.

## Installation

### 1. Install OpenXR Plugin
1. In Unity, go to **Window > Package Manager**
2. Click the **+** icon (top-left)
3. Select **Add package from git URL**
4. Enter: `com.unity.xr.openxr`
5. Click **Add**
6. Wait for installation to complete

### 2. Install XR Interaction Toolkit (Recommended)
1. Still in Package Manager
2. Search for **XR Interaction Toolkit**
3. Click **Install**
4. When prompted about Input System, click **Yes** and allow editor restart

### 3. Configure XR Plug-in Management
1. Go to **Edit > Project Settings**
2. Navigate to **XR Plug-in Management**

#### Desktop (PC VR) Settings
1. Select **PC, Mac & Linux Standalone** tab (monitor icon)
2. Check **OpenXR**
3. Under **OpenXR > Interaction Profiles**, add:
   - **Oculus Touch Controller Profile**
   - **Valve Index Controller Profile**
   - **HTC Vive Controller Profile**

#### Android (Quest) Settings
1. Select **Android** tab (robot icon)
2. Check **OpenXR**
3. Under **OpenXR > Interaction Profiles**, add:
   - **Oculus Touch Controller Profile**
4. Click the **warning icon** (if present) and resolve any issues

### 4. Validation
1. In **Project Settings > XR Plug-in Management > OpenXR**
2. Click the **validation** icon (checkmark/exclamation)
3. Fix any critical errors (red)
4. Warnings (yellow) are usually acceptable

### 5. Input Actions Setup
1. Go to **Edit > Project Settings > XR Interaction Toolkit**
2. Click **Create Default Input Actions**
3. Save the generated asset to `Assets/_Project/Settings/`

## Common Issues

### "No XR SDK loaded"
- Ensure OpenXR is checked in XR Plug-in Management for your target platform

### "Missing Interaction Profile"
- Add Oculus Touch Controller Profile in OpenXR settings

### Input not working
- Verify Input System package is installed
- Check Input Actions are properly configured

## Next Steps
- Proceed to [Scene Setup Guide](scene_setup.md)
