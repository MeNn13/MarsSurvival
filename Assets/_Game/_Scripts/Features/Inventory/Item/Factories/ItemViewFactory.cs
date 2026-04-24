using _Game._Scripts.Core.Data.Entities;
using _Game._Scripts.Features.Inventory.Slot;
using UnityEngine;

namespace _Game._Scripts.Features.Inventory.Item.Factories
{
    public class ItemViewFactory : IItemViewFactory
    {
        private readonly ItemView _prefab;
        private readonly Transform _dragArea;

        public ItemViewFactory(ItemView prefab, Transform dragArea)
        {
            _prefab = prefab;
            _dragArea = dragArea;
        }

        public ItemView Create(ItemEntity itemEntity, SlotView slot)
        {
            var item = Object.Instantiate(_prefab, slot.transform);
            item.Initialize(itemEntity, slot);
            
            var dragHandler = item.GetComponent<ItemDragHandler>();
            dragHandler?.SetDragArea(_dragArea);
            
            return item;
        }
    }
}
