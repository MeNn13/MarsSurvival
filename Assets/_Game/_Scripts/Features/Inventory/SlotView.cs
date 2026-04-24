using System;
using _Game._Scripts.Features.Inventory.Item;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace _Game._Scripts.Features.Inventory
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
                itemView = value;
                if (itemView is null) 
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

        private IItemManager _itemManager;
        
        [Inject]
        public void Construct(IItemManager itemManager)
        {
            _itemManager = itemManager;
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
            
            _itemManager.DropItemInSlot(droppedItem, this);
            
            OnDropItem?.Invoke(droppedItem);
        }
    }
}
