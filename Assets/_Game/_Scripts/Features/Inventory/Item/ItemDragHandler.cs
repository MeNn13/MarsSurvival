using System.Collections.Generic;
using System.Linq;
using _Game._Scripts.Features.Inventory.Slot;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Game._Scripts.Features.Inventory.Item
{
    public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Transform _dragArea;
        private ItemView _itemView;
        private Image _image;

        private void Awake()
        {
            _itemView = GetComponent<ItemView>();
            _image = GetComponent<Image>();
        }

        public void SetDragArea(Transform dragArea) => 
            _dragArea = dragArea;

        public void OnBeginDrag(PointerEventData eventData)
        {
            _image.raycastTarget = false;
            transform.SetParent(_dragArea);
        }

        public void OnDrag(PointerEventData eventData) => 
            transform.position = Input.mousePosition;

        public void OnEndDrag(PointerEventData eventData)
        {
            _image.raycastTarget = true;

            if (DroppedOutsideInventory(eventData))
            {
                // ETilemap.CreateDropObjectFromScreen(eventData.position, itemEntity);
                _itemView.Destroy();
            }
        }

        private bool DroppedOutsideInventory(PointerEventData eventData)
        {
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            return results.All(r => r.gameObject.GetComponent<SlotView>() is null);
        }
    }
}
