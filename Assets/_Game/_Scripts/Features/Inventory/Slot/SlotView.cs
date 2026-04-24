using System;
using _Game._Scripts.Features.Inventory.Item;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace _Game._Scripts.Features.Inventory.Slot
{
    public class SlotView : MonoBehaviour, IDropHandler
    {
        public event Action<ItemView> OnDropItem;
        public event Action OnEmpty;
        
        public bool IsEmpty => itemView is null;
        public ItemView ItemView
        {
            get => itemView;
            set {
                var wasEmpty = itemView is null;
                itemView = value;
    
                if (itemView is null && !wasEmpty)
                    OnEmpty?.Invoke();
            }
        }

        [Header("Attributes")]
        [SerializeField] private bool interactable = true;
        [SerializeField] private ItemView itemView;

        [Header("UI")] 
        [SerializeField] private Image image;
        [SerializeField] private Sprite selectIcon;
        [SerializeField] private Color selectColor;
        [SerializeField] private Sprite deselectIcon;
        [SerializeField] private Color deselectColor;

        private IInventory _inventory;
        
        [Inject]
        public void Construct(IInventory  inventory)
        {
            _inventory = inventory;
        }
        
        public void Select()
        {
            image.sprite = selectIcon;
            image.color = selectColor;
        }
        
        public void Deselect()
        {
            image.sprite = deselectIcon;
            image.color = deselectColor;
        }
        
        public void OnDrop(PointerEventData eventData)
        {
            if (!interactable)
                return;
            
            if(!eventData.pointerDrag.TryGetComponent(out ItemView droppedItem)) return;
            
            if (droppedItem == itemView) return;
            
            _inventory.HandleDrop(droppedItem, this);
            
            OnDropItem?.Invoke(droppedItem);
        }
    }
}
