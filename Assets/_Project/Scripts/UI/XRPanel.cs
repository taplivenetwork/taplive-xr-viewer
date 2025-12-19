using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TapLive.UI
{
    /// <summary>
    /// Generic XR panel for world-space UI
    /// Can display order information or other data
    /// </summary>
    public class XRPanel : MonoBehaviour
    {
        [Header("UI Elements")]
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI descriptionText;
        public Image iconImage;
        public Button actionButton;

        [Header("Settings")]
        public bool faceCamera = true;

        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
            
            if (actionButton != null)
            {
                actionButton.onClick.AddListener(OnActionButtonClicked);
            }
        }

        private void Update()
        {
            if (faceCamera && _mainCamera != null)
            {
                transform.LookAt(_mainCamera.transform);
                transform.Rotate(0, 180, 0); // Flip to face camera
            }
        }

        public void SetTitle(string title)
        {
            if (titleText != null)
            {
                titleText.text = title;
            }
        }

        public void SetDescription(string description)
        {
            if (descriptionText != null)
            {
                descriptionText.text = description;
            }
        }

        public void SetIcon(Sprite sprite)
        {
            if (iconImage != null)
            {
                iconImage.sprite = sprite;
            }
        }

        private void OnActionButtonClicked()
        {
            Debug.Log($"[XRPanel] Action button clicked on panel: {gameObject.name}");
            // TODO: Implement action logic
        }

        private void OnDestroy()
        {
            if (actionButton != null)
            {
                actionButton.onClick.RemoveListener(OnActionButtonClicked);
            }
        }
    }
}
