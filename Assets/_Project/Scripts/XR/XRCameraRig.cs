using UnityEngine;

namespace TapLive.XR
{
    /// <summary>
    /// Manages XR camera rig configuration and room-scale setup
    /// </summary>
    public class XRCameraRig : MonoBehaviour
    {
        [Header("Camera Settings")]
        public Camera xrCamera;
        public Transform leftController;
        public Transform rightController;

        [Header("Room-Scale Settings")]
        public float playerHeight = 1.8f;
        public bool enableBoundaryVisuals = true;

        private void Start()
        {
            InitializeRig();
        }

        private void InitializeRig()
        {
            Debug.Log("[XRCameraRig] Initializing XR camera rig...");
            
            // Auto-find XR camera if not assigned
            if (xrCamera == null)
            {
                xrCamera = GetComponentInChildren<Camera>();
                if (xrCamera == null)
                {
                    Debug.LogWarning("[XRCameraRig] No camera found in XR rig.");
                }
            }

            // Configure camera settings
            if (xrCamera != null)
            {
                xrCamera.nearClipPlane = 0.01f;
                xrCamera.farClipPlane = 1000f;
            }

            // Find controllers if using XR Interaction Toolkit
            FindControllers();
        }

        private void FindControllers()
        {
            // Auto-detect controllers if not manually assigned
            Transform[] children = GetComponentsInChildren<Transform>();
            
            foreach (var child in children)
            {
                if (leftController == null && child.name.ToLower().Contains("left"))
                {
                    leftController = child;
                    Debug.Log($"[XRCameraRig] Found left controller: {child.name}");
                }
                
                if (rightController == null && child.name.ToLower().Contains("right"))
                {
                    rightController = child;
                    Debug.Log($"[XRCameraRig] Found right controller: {child.name}");
                }
            }
        }

        public Vector3 GetHeadPosition()
        {
            return xrCamera != null ? xrCamera.transform.position : transform.position;
        }

        public Quaternion GetHeadRotation()
        {
            return xrCamera != null ? xrCamera.transform.rotation : transform.rotation;
        }
    }
}
