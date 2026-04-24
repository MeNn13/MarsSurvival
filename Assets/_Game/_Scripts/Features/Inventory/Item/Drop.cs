using _Game._Scripts.Core.Data.Entities;
using UnityEngine;

namespace _Game._Scripts.Features.Inventory.Item
{
    public class Drop : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        public ItemEntity item;

        private void Start()
        {
            spriteRenderer.sprite = item?.itemData?.Icon;
        }
    }
}
