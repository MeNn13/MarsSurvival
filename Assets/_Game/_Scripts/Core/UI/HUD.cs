using UnityEngine;
using UnityEngine.UI;

namespace _Game._Scripts.Core.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private Slider oxygenSlider;
        [SerializeField] private Slider healthSlider;

        [Header("Overload")]
        [SerializeField] private Slider overloadSlider;
        [SerializeField] private Image overloadFillImage;
        [SerializeField] private Color minOverloadColor = Color.yellowNice;
        [SerializeField] private Color maxOverloadColor = Color.red;

        public void UpdateOxygen(float maxCount, float count)
        {
            oxygenSlider.maxValue = maxCount;
            oxygenSlider.value = count;
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
    }
}
