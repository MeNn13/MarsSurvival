using UnityEngine;
using UnityEngine.UI;

namespace _Game._Scripts.Core.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private Slider oxygenSlider;
        [SerializeField] private Slider healthSlider;
        
        public void UpdateOxygen(float maxCount, float count)
        {
            oxygenSlider.maxValue = maxCount;
            oxygenSlider.value = count;
        }
    }
}
