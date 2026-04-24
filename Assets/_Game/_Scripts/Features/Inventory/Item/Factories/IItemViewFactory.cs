using _Game._Scripts.Core.Data.Entities;
using _Game._Scripts.Features.Inventory.Slot;

namespace _Game._Scripts.Features.Inventory.Item.Factories
{
    public interface IItemViewFactory
    {
        ItemView Create(ItemEntity itemEntity, SlotView slot);
    }
}
