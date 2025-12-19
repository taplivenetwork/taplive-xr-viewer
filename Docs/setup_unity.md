# Unity Setup Guide

## Prerequisites
- **Unity Hub**: Latest version installed
- **Unity Editor**: Unity 6 (6000.0 or newer) recommended, or 2022.3 LTS minimum
- **Build Support**: 
  - Android Build Support (OpenJDK & Android SDK)
  - Windows Build Support (if targeting PCVR)

## Installation Steps

### 1. Install Unity
1. Download and install [Unity Hub](https://unity.com/download)
2. Open Unity Hub
3. Navigate to **Installs** tab
4. Click **Install Editor**
5. Select **Unity 6 (6000.0 or newer)** - the latest release
6. In the installation options, ensure the following are checked:
   - **Android Build Support** (with OpenJDK and Android SDK)
   - **Windows Build Support**
   - **Documentation**
7. Click **Install** and wait for completion

### 2. Open Project
1. In Unity Hub, go to **Projects** tab
2. Click **Add** > **Add project from disk**
3. Navigate to `taplive-xr` folder
4. Click **Select Folder**
5. Unity will import and compile the project (this may take several minutes)

### 3. Verify Installation
- Check **Console** window for any errors
- Ensure no red compilation errors
- Warnings about missing packages are normal at this stage

## Next Steps
- Proceed to [OpenXR Setup](setup_openxr.md)
- Then follow [Scene Setup Guide](scene_setup.md)
