using _Game._Scripts.Features.Inventory;
using UnityEngine;
using Zenject;

namespace _Game._Scripts.Core.UI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private SlotView[] slots;
        [SerializeField] private GameObject backpack;
        
        private IInventory _inventory;
        
        [Inject]
        public void Construct(IInventory inventory) => _inventory = inventory;

        private void Start() => _inventory.Initialize(slots);
    }
}
