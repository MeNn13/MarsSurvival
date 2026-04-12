using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace _Game._Scripts.Core.UI
{
    public class PlayerWorldUI : MonoBehaviour
    {
        [Header("Overload")] [SerializeField] private Slider overloadSlider;
        [SerializeField] private Image overloadFillImage;
        [SerializeField] private Color minOverloadColor = Color.yellowNice;
        [SerializeField] private Color maxOverloadColor = Color.red;

        [Header("Follow Cursor")] [SerializeField] private Vector2 cursorOffset = new(20f, 20f);
        [SerializeField] private Canvas parentCanvas;
        [SerializeField] private RectTransform rectTransform;

        private Mouse _mouse;

        private void Start()
        {
            _mouse = Mouse.current;
            overloadSlider.gameObject.SetActive(false);
        }

        private void Update()
        {
            UpdatePosition();
        }

        public void UpdateOverload(float maxCount, float count)
        {
            overloadSlider.gameObject.SetActive(overloadSlider.value > 0);

            overloadSlider.maxValue = maxCount;
            overloadSlider.value = count;

            var fillRatio = count / maxCount;
            var color = Color.Lerp(minOverloadColor, maxOverloadColor, fillRatio);
            overloadFillImage.color = color;
        }

        private void UpdatePosition()
        {
            Vector2 mouseScreenPosition = _mouse.position.ReadValue();
            
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                parentCanvas.transform as RectTransform,
                mouseScreenPosition,
                parentCanvas.worldCamera,
                out Vector2 mousePosition);

            rectTransform.anchoredPosition = mousePosition + cursorOffset;
        }
    }
}
