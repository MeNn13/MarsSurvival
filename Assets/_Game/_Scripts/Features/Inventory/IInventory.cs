using _Game._Scripts.Core.Data.Entities;
using _Game._Scripts.Core.Data.ScriptableObjects;

namespace _Game._Scripts.Features.Inventory
{
    public interface IInventory
    {
        void Initialize(SlotView[] slots);
        bool AddItem(ItemEntity item);
        bool RemoveItem(ItemEntity item);
        bool HasItem(ItemData itemData, int count = 1);
        ItemData GetSelectedItem(bool use);
        void SelectSlot(int index);
    }

}
