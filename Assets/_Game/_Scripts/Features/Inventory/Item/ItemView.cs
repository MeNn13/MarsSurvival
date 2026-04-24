using _Game._Scripts.Core.Data.Entities;
using _Game._Scripts.Features.Inventory.Slot;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Game._Scripts.Features.Inventory.Item
{
    [RequireComponent(typeof(Image), typeof(ItemDragHandler))]
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI countText;
        [SerializeField] private Image image;

        public SlotView ParentSlot { get; private set; }
        public ItemEntity ItemEntity { get; private set; }

        public void Initialize(ItemEntity item, SlotView slotView)
        {
            if (item is null || slotView is null)
                return;

            ItemEntity = item;
            ParentSlot = slotView;
            image.sprite = item.ItemData.Icon;
            RefreshCount();
        }
        
        public void AttachTo(SlotView slot)
        {
            ParentSlot = slot;
            transform.SetParent(slot.transform);
            transform.localPosition = Vector3.zero;
        }
        
        public void RefreshCount()
        {
            countText.text = ItemEntity.Count.ToString();
            countText.gameObject.SetActive(ItemEntity.Count > 1);
        }

        public void Destroy() => 
            Object.Destroy(gameObject);
    }
}
