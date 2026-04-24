using System.Collections.Generic;
using System.Linq;
using _Game._Scripts.Core.Data.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Game._Scripts.Features.Inventory.Item
{
    [RequireComponent(typeof(Image))]
    public class ItemView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private TextMeshProUGUI countText;
        [SerializeField] private SlotView parentSlot;
        public SlotView ParentSlot => parentSlot;
        public ItemEntity itemEntity;
        private Transform DragArea => parentSlot?.transform.parent.transform.parent;
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
            Initialize(itemEntity, parentSlot);
        }

        public void Initialize(ItemEntity item, SlotView slotView)
        {
            if (item is null || slotView is null)
                return;

            itemEntity = item;
            parentSlot = slotView;
            _image.sprite = itemEntity.itemData.Icon;
            RefreshCount();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _image.raycastTarget = false; 
            transform.SetParent(DragArea);
        }
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            _image.raycastTarget = true;

            if (DroppedOutsideInventory(eventData))
            {
               // ETilemap.CreateDropObjectFromScreen(eventData.position, itemEntity);
                Destroy();
            }
        }
        public void UpdateParent(SlotView parent)
        {
            transform.SetParent(parent.transform);
            parentSlot = parent;
            transform.localPosition = Vector3.zero;
            
        }
        public void RefreshCount()
        {
            countText.text = itemEntity.count.ToString();
            bool textActive = itemEntity.count > 1;
            countText.gameObject.SetActive(textActive);
        }
        public void Destroy()
        {
            Object.Destroy(gameObject);
        }

        private bool DroppedOutsideInventory(PointerEventData eventData)
        {
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            return results.All(result => result.gameObject.GetComponent<SlotView>() is null);
        }
    }
}
