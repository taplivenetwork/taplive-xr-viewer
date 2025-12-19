using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace TapLive.UI
{
    /// <summary>
    /// XR-enabled button with hover and click interactions
    /// Works with XR raycasting and pointer events
    /// </summary>
    public class XRButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [Header("Visual Feedback")]
        public Color normalColor = Color.white;
        public Color hoverColor = Color.cyan;
        public Color pressedColor = Color.green;
        public float scaleFactor = 1.1f;

        [Header("Events")]
        public UnityEvent onClick;

        private Renderer _renderer;
        private Vector3 _originalScale;
        private bool _isHovered = false;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            _originalScale = transform.localScale;
            
            if (_renderer != null)
            {
                _renderer.material.color = normalColor;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _isHovered = true;
            
            if (_renderer != null)
            {
                _renderer.material.color = hoverColor;
            }
            
            transform.localScale = _originalScale * scaleFactor;
            Debug.Log($"[XRButton] Hover enter: {gameObject.name}");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _isHovered = false;
            
            if (_renderer != null)
            {
                _renderer.material.color = normalColor;
            }
            
            transform.localScale = _originalScale;
            Debug.Log($"[XRButton] Hover exit: {gameObject.name}");
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"[XRButton] Clicked: {gameObject.name}");
            
            // Visual feedback
            if (_renderer != null)
            {
                _renderer.material.color = pressedColor;
                Invoke(nameof(ResetColor), 0.1f);
            }
            
            // Invoke event
            onClick?.Invoke();
        }

        private void ResetColor()
        {
            if (_renderer != null)
            {
                _renderer.material.color = _isHovered ? hoverColor : normalColor;
            }
        }
    }
}
