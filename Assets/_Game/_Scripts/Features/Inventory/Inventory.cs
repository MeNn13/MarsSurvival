using System.Linq;
using _Game._Scripts.Core.Data.Entities;
using _Game._Scripts.Core.Data.ScriptableObjects;
using _Game._Scripts.Features.Inventory.Item;
using _Game._Scripts.Features.Inventory.Item.Factories;
using _Game._Scripts.Features.Inventory.Slot;

namespace _Game._Scripts.Features.Inventory
{
    public class Inventory : IInventory
    {
        private SlotView[] _slots;
        private SlotSelector _slotSelector;
        private readonly IItemViewFactory _itemViewFactory;

        public Inventory(IItemViewFactory itemViewFactory)
        {
            _itemViewFactory = itemViewFactory;
        }

        public void Initialize(SlotView[] slots)
        {
            _slots = slots;
            _slotSelector = new SlotSelector(slots);

            if (_slots.Length > 0)
                _slotSelector.Select(0);
        }

        public bool AddItem(ItemEntity itemEntity) =>
            TryAddToExistingStack(itemEntity) || TryAddToEmptySlot(itemEntity);

        public bool RemoveItem(ItemEntity item)
        {
            throw new System.NotImplementedException();
        }

        public bool HasItem(ItemData itemData, int count = 1)
        {
            return _slots
                       .Where(slot => slot.ItemView is not null
                                      && slot.ItemView.ItemEntity.ItemData == itemData)
                       .Sum(slot => slot.ItemView.ItemEntity.Count)
                   >= count;
        }

        public ItemData GetSelectedItem(bool use)
        {
            var slot = _slotSelector.SelectedSlot;
            if (slot?.ItemView is null)
                return null;

            var itemData = slot.ItemView.ItemEntity.ItemData;

            if (use) UseItemInSlot(slot);

            return itemData;
        }

        public void SelectSlot(int index) =>
            _slotSelector.Select(index);

        public void HandleDrop(ItemView droppedItem, SlotView targetSlot)
        {
            if (!IsValidDrop(droppedItem, targetSlot))
                return;

            if (droppedItem.ParentSlot == targetSlot)
            {
                PlaceBack(droppedItem);
                return;
            }

            if (!TryStackIntoSlot(droppedItem, targetSlot))
                SwapItems(droppedItem, targetSlot);
        }

        private bool TryAddToExistingStack(ItemEntity itemEntity) =>
            _slots.Any(slot => slot.ItemView is not null && TryStackInto(slot.ItemView, itemEntity));
        private bool TryStackInto(ItemView target, ItemEntity incoming)
        {
            var targetEntity = target.ItemEntity;

            if (!CanStack(targetEntity, incoming))
                return false;

            targetEntity.Add(incoming.Count);
            target.RefreshCount();

            return true;
        }
        private bool TryAddToEmptySlot(ItemEntity itemEntity)
        {
            var emptySlot = FindEmptySlot();

            if (emptySlot is null)
                return false;

            var itemView = _itemViewFactory.Create(itemEntity, emptySlot);
            emptySlot.ItemView = itemView;

            return true;
        }
        
        private bool IsValidDrop(ItemView item, SlotView slot) => 
            item is not null && slot is not null && item.ParentSlot is not null;
        private void PlaceBack(ItemView item)
        {
            item.AttachTo(item.ParentSlot);
            item.ParentSlot.ItemView = item;
        }
        private bool TryStackIntoSlot(ItemView droppedItem, SlotView targetSlot)
        {
            if (targetSlot.IsEmpty)
                return false;

            if (!TryStackInto(targetSlot.ItemView, droppedItem.ItemEntity))
                return false;
            
            droppedItem.Destroy();
            return true;
        }
        private void SwapItems(ItemView droppedItem, SlotView targetSlot)
        {
            var sourceSlot = droppedItem.ParentSlot;
            var targetItem = targetSlot.ItemView;

            droppedItem.AttachTo(targetSlot);
            targetSlot.ItemView = droppedItem;

            targetItem?.AttachTo(sourceSlot);
            sourceSlot.ItemView = targetItem;
        }

        private void UseItemInSlot(SlotView slot)
                {
                    var entity = slot.ItemView.ItemEntity;
                    entity.Remove(1);
        
                    if (entity.IsEmpty)
                    {
                        slot.ItemView.Destroy();
                        slot.ItemView = null;
        
                        return;
                    }
        
                    slot.ItemView.RefreshCount();
                }
        private bool CanStack(ItemEntity target, ItemEntity incoming)
                {
                    return target.ItemData == incoming.ItemData
                           && incoming.ItemData.Stackable
                           && target.Count + incoming.Count <= InventoryConstants.MAX_STACK;
                }
        private SlotView FindEmptySlot() =>
            _slots.FirstOrDefault(s => s.IsEmpty);
    }
}
