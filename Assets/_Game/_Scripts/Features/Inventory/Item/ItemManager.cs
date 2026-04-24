using _Game._Scripts.Core.Data.Entities;
using UnityEngine;

namespace _Game._Scripts.Features.Inventory.Item
{
    public class ItemManager : IItemManager
    {
        private readonly ItemView _itemViewPrefab;

        public ItemManager(ItemView itemViewPrefab)
        {
            _itemViewPrefab = itemViewPrefab;
        }

        public ItemView CreateItem(ItemEntity itemEntity, SlotView slot)
        {
            var item = Object.Instantiate(_itemViewPrefab, slot.transform);
            item.Initialize(itemEntity, slot);
            return item;
        }
        
        public void DropItemInSlot(ItemView droppedItem, SlotView targetSlot)
        {
            if (droppedItem is null || targetSlot is null) return;
            
            var sourceSlot = droppedItem.ParentSlot;
            if (sourceSlot is null) return;
            
            if (sourceSlot == targetSlot) 
            {
                ReturnItemToSlot(droppedItem, sourceSlot);
                return;
            }
            
            if (TryAddCountInItem(droppedItem, targetSlot))
                return;

            SwapItems(sourceSlot, targetSlot, droppedItem);
        }
        
        private void ReturnItemToSlot(ItemView item, SlotView slot)
        {
            item.UpdateParent(slot);
            slot.ItemView = item;
        }
        private bool TryAddCountInItem(ItemView droppedItem, SlotView targetSlot)
        {
            if (targetSlot.IsEmpty) return false;
            
            var targetItem = targetSlot.ItemView;
            var droppedEntity = droppedItem.itemEntity;
            var targetEntity = targetItem.itemEntity;
            
            if (targetEntity.itemData != droppedEntity.itemData) return false;
            if (!targetEntity.itemData.Stackable) return false;

            var sumCount = targetEntity.count + droppedEntity.count;
            if (sumCount > InventoryConstants.MAX_STACK) return false;

            targetEntity.count = sumCount;
            targetItem.RefreshCount();
            
            droppedItem.Destroy();
            
            return true;
        }
        private void SwapItems(SlotView sourceSlot, SlotView targetSlot, ItemView droppedItem)
        {
            ItemView targetItem = targetSlot.ItemView;
            
            droppedItem.UpdateParent(targetSlot);
            targetSlot.ItemView = droppedItem;

            if (targetItem != null)
            {
                targetItem.UpdateParent(sourceSlot);
                sourceSlot.ItemView = targetItem;
                return;
            }
            
            sourceSlot.ItemView = null;
        }
    }
}
