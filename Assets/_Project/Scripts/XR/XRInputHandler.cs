using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace TapLive.XR
{
    /// <summary>
    /// Handles XR input from controllers and maps to actions
    /// Refactored from VRInputHandler to support general XR interactions
    /// </summary>
    public class XRInputHandler : MonoBehaviour
    {
        [Header("Video Controls")]
        public Scripts.VideoController videoController;

        [Header("Input Actions (New Input System)")]
#if ENABLE_INPUT_SYSTEM
        public InputActionProperty playPauseAction;
        public InputActionProperty seekRightAction;
        public InputActionProperty seekLeftAction;
        public InputActionProperty menuAction;
#endif

        [Header("Fallback / Debug Keys")]
        public KeyCode debugPlayPause = KeyCode.Space;
        public KeyCode debugSeekFwd = KeyCode.RightArrow;
        public KeyCode debugSeekBack = KeyCode.LeftArrow;
        public KeyCode debugMenu = KeyCode.Escape;

        private void OnEnable()
        {
#if ENABLE_INPUT_SYSTEM
            playPauseAction.action?.Enable();
            seekRightAction.action?.Enable();
            seekLeftAction.action?.Enable();
            menuAction.action?.Enable();
#endif
        }

        private void OnDisable()
        {
#if ENABLE_INPUT_SYSTEM
            playPauseAction.action?.Disable();
            seekRightAction.action?.Disable();
            seekLeftAction.action?.Disable();
            menuAction.action?.Disable();
#endif
        }

        private void Update()
        {
            HandleVideoControls();
            HandleMenuControls();
        }

        private void HandleVideoControls()
        {
            if (videoController == null) return;

            // Check Input System Actions
#if ENABLE_INPUT_SYSTEM
            if (playPauseAction.action != null && playPauseAction.action.WasPerformedThisFrame())
            {
                videoController.TogglePlayPause();
            }
            
            if (seekRightAction.action != null && seekRightAction.action.WasPerformedThisFrame())
            {
                videoController.SeekForward();
            }
            
            if (seekLeftAction.action != null && seekLeftAction.action.WasPerformedThisFrame())
            {
                videoController.SeekBackward();
            }
#endif

            // Check Fallback Keys
            if (Input.GetKeyDown(debugPlayPause))
            {
                videoController.TogglePlayPause();
            }
            if (Input.GetKeyDown(debugSeekFwd))
            {
                videoController.SeekForward();
            }
            if (Input.GetKeyDown(debugSeekBack))
            {
                videoController.SeekBackward();
            }
        }

        private void HandleMenuControls()
        {
#if ENABLE_INPUT_SYSTEM
            if (menuAction.action != null && menuAction.action.WasPerformedThisFrame())
            {
                ToggleMenu();
            }
#endif
            if (Input.GetKeyDown(debugMenu))
            {
                ToggleMenu();
            }
        }

        private void ToggleMenu()
        {
            Debug.Log("[XRInputHandler] Menu toggle (TODO: Implement UI panel)");
            // TODO: Toggle XR menu panel
        }
    }
}
