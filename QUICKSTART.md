# TapLive XR - Quick Start README

## ⚡ Immediate Next Steps

### Phase 1: Unity Setup (5-10 minutes)
1. **Install Unity Hub** from https://unity.com/download
2. **Install Unity 6 (6000.0 or newer)** with:
   - Android Build Support (for Quest)
   - Windows Build Support (for PCVR)
3. **Open this project** in Unity Hub:
   - Click "Add" → Select `taplive-xr` folder
   - Wait for import (3-5 minutes)

### Phase 2: OpenXR Setup (5 minutes)
1. In Unity, open **Window → Package Manager**
2. Click **+ → Add package by name**
3. Enter: `com.unity.xr.openxr` and click **Add**
4. Install **XR Interaction Toolkit** (search in Package Manager)
5. When prompted about Input System, click **Yes** and restart

### Phase 3: Configure and Test (2 minutes)
1. **Edit → Project Settings → XR Plug-in Management**
2. Check **OpenXR** for both PC and Android tabs
3. Under **OpenXR → Interaction Profiles**, add:
   - Oculus Touch Controller Profile
4. Open scene: `Assets/_Project/Scenes/Bootstrap.unity`
5. Press **Play** to test!

## 📋 What's Already Done

✅ **18 C# scripts** - All organized and compiled  
✅ **Config files** - Mock data ready  
✅ **Documentation** - Complete guides in `/Docs`  
✅ **Auto-setup** - Runs automatically when you open Unity  
✅ **Quick Start script** - For instant testing  

## 🎯 First Test

After opening the project in Unity:
1. Open `Bootstrap.unity` scene
2. Press Play
3. Check Console for "AppManager initialized"
4. See config loaded from `StreamingAssets/app_config.json`

## 📚 Full Documentation

See `/Docs` folder for detailed guides:
- `setup_unity.md` - Unity installation
- `setup_openxr.md` - OpenXR configuration  
- `scene_setup.md` - Scene creation
- `api_integration.md` - Network setup
- `build_meta_quest.md` - Deploy to Quest

## ⚠️ Common Issues

**"No XR SDK loaded"**
→ Install OpenXR plugin via Package Manager

**"Missing namespace"**
→ Ensure project has finished importing (check spinning icon in bottom-right)

**"Input not working"**
→ Install XR Interaction Toolkit and create Default Input Actions

## 🚀 Ready to Build?

Once scenes are set up, follow `Docs/build_meta_quest.md` to deploy to your Quest headset!
