using _Game._Scripts.Core.Data.Entities;

namespace _Game._Scripts.Features.Inventory.Item
{
    public interface IItemManager
    {
        ItemView CreateItem(ItemEntity itemEntity, SlotView slot);
        void DropItemInSlot(ItemView droppedItem, SlotView targetSlot);
    }
}
