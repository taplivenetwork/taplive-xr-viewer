using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TapLive.UI
{
    /// <summary>
    /// XR Heads-up display controller
    /// Manages persistent UI elements visible to the user
    /// </summary>
    public class XRHUD : MonoBehaviour
    {
        [Header("UI Elements")]
        public TextMeshProUGUI statusText;
        public TextMeshProUGUI fpsText;
        public Image connectionIndicator;

        [Header("Settings")]
        public bool showFPS = true;
        public Color connectedColor = Color.green;
        public Color disconnectedColor = Color.red;

        private float _deltaTime = 0f;

        private void Update()
        {
            if (showFPS && fpsText != null)
            {
                UpdateFPS();
            }
        }

        public void SetStatusText(string text)
        {
            if (statusText != null)
            {
                statusText.text = text;
            }
        }

        public void SetConnectionStatus(bool connected)
        {
            if (connectionIndicator != null)
            {
                connectionIndicator.color = connected ? connectedColor : disconnectedColor;
            }
        }

        private void UpdateFPS()
        {
            _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
            float fps = 1.0f / _deltaTime;
            fpsText.text = $"FPS: {Mathf.Ceil(fps)}";
        }
    }
}
