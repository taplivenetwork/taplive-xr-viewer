using UnityEngine;
using UnityEngine.EventSystems;

namespace TapLive.XR
{
    /// <summary>
    /// Binds world-space UI to XR controllers and handles raycasting
    /// </summary>
    public class XRUIBinder : MonoBehaviour
    {
        [Header("UI Settings")]
        public Canvas worldSpaceCanvas;
        public float raycastMaxDistance = 10f;
        
        [Header("Raycast Visual")]
        public LineRenderer raycastLine;
        public Color rayHitColor = Color.green;
        public Color rayMissColor = Color.white;

        private Camera _xrCamera;

        private void Start()
        {
            InitializeUIBinder();
        }

        private void InitializeUIBinder()
        {
            Debug.Log("[XRUIBinder] Initializing UI binder...");
            
            // Find XR camera
            _xrCamera = Camera.main;
            
            // Setup canvas if assigned
            if (worldSpaceCanvas != null)
            {
                worldSpaceCanvas.renderMode = RenderMode.WorldSpace;
                
                // Add Event System if not present
                if (FindObjectOfType<EventSystem>() == null)
                {
                    var eventSystem = new GameObject("EventSystem");
                    eventSystem.AddComponent<EventSystem>();
                    eventSystem.AddComponent<StandaloneInputModule>();
                }
            }
            
            // Setup ray visual
            if (raycastLine != null)
            {
                raycastLine.startWidth = 0.01f;
                raycastLine.endWidth = 0.01f;
            }
        }

        private void Update()
        {
            UpdateRaycast();
        }

        private void UpdateRaycast()
        {
            if (_xrCamera == null || raycastLine == null) return;

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            bool didHit = Physics.Raycast(ray, out hit, raycastMaxDistance);

            // Update line visual
            raycastLine.SetPosition(0, transform.position);
            
            if (didHit)
            {
                raycastLine.SetPosition(1, hit.point);
                raycastLine.startColor = rayHitColor;
                raycastLine.endColor = rayHitColor;
            }
            else
            {
                raycastLine.SetPosition(1, transform.position + transform.forward * raycastMaxDistance);
                raycastLine.startColor = rayMissColor;
                raycastLine.endColor = rayMissColor;
            }
        }

        public void BindCanvas(Canvas canvas)
        {
            worldSpaceCanvas = canvas;
            worldSpaceCanvas.renderMode = RenderMode.WorldSpace;
        }
    }
}
