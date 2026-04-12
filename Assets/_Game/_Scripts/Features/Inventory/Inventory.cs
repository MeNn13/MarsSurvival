using System.Linq;
using _Game._Scripts.Core.Data.Entities;
using _Game._Scripts.Core.Data.ScriptableObjects;

namespace _Game._Scripts.Features.Inventory
{
    public class Inventory : IInventory
    {
        private const int MAX_STACK = 99;
        
        private SlotView[] _slots;
        private int _selectedSlotIndex = -1;
        //private readonly IItemManager itemManager;

        //public InventoryManager(IItemManager itemManager)
        // {
        //     this.itemManager = itemManager;
        // }

        public void Initialize(SlotView[] slots)
        {
            _slots = slots;

            if (_slots.Length > 0)
                SelectSlot(0);
        }

        public bool AddItem(ItemEntity itemEntity) =>
            TryAddToExistingStack(itemEntity) && AddNewItem(itemEntity);

        public bool RemoveItem(ItemEntity item)
        {
            throw new System.NotImplementedException();
        }

        public bool HasItem(ItemData itemData, int count = 1)
        {
            return _slots
                       .Where(slot => slot.ItemView is not null && slot.ItemView.itemEntity.itemData == itemData)
                       .Sum(slot => slot.ItemView.itemEntity.count)
                   >= count;
        }

        public ItemData GetSelectedItem(bool use)
        {
            if (_selectedSlotIndex < 0 || _selectedSlotIndex >= _slots.Length)
                return null;

            var selectedSlot = _slots[_selectedSlotIndex];
            if (selectedSlot.ItemView is null)
                return null;

            var itemData = selectedSlot.ItemView.itemEntity.itemData;

            if (use)
            {
                UseItemInSlot(selectedSlot);
            }

            return itemData;
        }

        public void SelectSlot(int index)
        {
            if (_selectedSlotIndex >= 0 && _selectedSlotIndex < _slots.Length)
                _slots[_selectedSlotIndex].Deselect();

            _slots[index].Select();
            _selectedSlotIndex = index;
        }

        private bool TryAddToExistingStack(ItemEntity itemEntity)
        {
            foreach (var slot in _slots)
            {
                var slotItem = slot.ItemView.itemEntity;
                var sumCount = slotItem.count + itemEntity.count;

                if (slot.ItemView is null) continue;
                if (!itemEntity.itemData.Stackable
                    && MAX_STACK >= sumCount) continue;

                slotItem.count += itemEntity.count;
                slot.ItemView.RefreshCount();
                return true;
            }
            return false;
        }
        private bool AddNewItem(ItemEntity itemEntity)
        {
            var emptySlot = FindEmptySlot();
            if (emptySlot is not null)
            {
                //var itemView = itemManager.CreateItem(itemEntity, emptySlot);
                //emptySlot.ItemView = itemView;
                return true;
            }
            return false;
        }
        private void UseItemInSlot(SlotView slot)
        {
            var itemEntity = slot.ItemView.itemEntity;
            itemEntity.count--;

            if (itemEntity.count <= 0)
            {
                slot.ItemView.Destroy();
                slot.ItemView = null;
            }
            else
            {
                slot.ItemView.RefreshCount();
            }
        }
        private SlotView FindEmptySlot() => _slots.FirstOrDefault(s => s.IsEmpty);
    }
}
