using UnityEngine;
#if UNITY_XR_MANAGEMENT
using UnityEngine.XR.Management;
#endif

namespace TapLive.Core
{
    /// <summary>
    /// Manages XR session state and device configuration
    /// </summary>
    public class XRManager : MonoBehaviour
    {
        public static XRManager Instance { get; private set; }

        [Header("XR Settings")]
        public bool autoStartXR = true;
        
        private bool _xrInitialized = false;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            
            Instance = this;
        }

        private void Start()
        {
            if (autoStartXR)
            {
                InitializeXR();
            }
        }

        public void InitializeXR()
        {
#if UNITY_XR_MANAGEMENT
            Debug.Log("[XRManager] Initializing XR...");
            
            var xrSettings = XRGeneralSettings.Instance;
            if (xrSettings != null)
            {
                var xrManager = xrSettings.Manager;
                if (xrManager != null && !xrManager.isInitializationComplete)
                {
                    xrManager.InitializeLoaderSync();
                    
                    if (xrManager.activeLoader != null)
                    {
                        xrManager.StartSubsystems();
                        _xrInitialized = true;
                        Debug.Log("[XRManager] XR initialized successfully.");
                    }
                    else
                    {
                        Debug.LogError("[XRManager] Failed to initialize XR loader.");
                    }
                }
                else
                {
                    _xrInitialized = true;
                    Debug.Log("[XRManager] XR already initialized.");
                }
            }
            else
            {
                Debug.LogWarning("[XRManager] XR General Settings not found.");
            }
#else
            Debug.LogWarning("[XRManager] XR Management package not installed.");
#endif
        }

        public bool IsXRActive()
        {
#if UNITY_XR_MANAGEMENT
            var xrSettings = XRGeneralSettings.Instance;
            return xrSettings != null && 
                   xrSettings.Manager != null && 
                   xrSettings.Manager.activeLoader != null;
#else
            return false;
#endif
        }

        private void OnDestroy()
        {
#if UNITY_XR_MANAGEMENT
            if (_xrInitialized)
            {
                var xrManager = XRGeneralSettings.Instance?.Manager;
                if (xrManager != null)
                {
                    xrManager.StopSubsystems();
                    xrManager.DeinitializeLoader();
                    Debug.Log("[XRManager] XR shutdown complete.");
                }
            }
#endif
        }
    }
}
