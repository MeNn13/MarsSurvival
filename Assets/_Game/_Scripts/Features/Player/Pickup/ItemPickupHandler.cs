using _Game._Scripts.Features.Inventory;
using _Game._Scripts.Features.Inventory.Item;
using UnityEngine;

namespace _Game._Scripts.Features.Player.Pickup
{
    public class ItemPickupHandler : IPickupHandler
    {
        private readonly IInventory _inventory;

        public ItemPickupHandler(IInventory inventory)
        {
            _inventory = inventory;
        }
        
        public void Handle(GameObject obj)
        {
            if (obj.TryGetComponent(out Drop drop) 
                && _inventory.AddItem(drop.item))
                Object.Destroy(obj);
        }
    }
}
