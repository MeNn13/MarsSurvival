using _Game._Scripts.Core.Input;
using UnityEngine;
using Zenject;

namespace _Game._Scripts.Features.Inventory
{
    public class InventoryInputController : MonoBehaviour
    {
        [SerializeField] private InputProvider input;
        [SerializeField] private GameObject backpackObj;

        private IInventory _inventory;
        private int _previousIndex;

        [Inject]
        public void Construct(IInventory inventory)
        {
            _inventory = inventory;
        }
        
        private void Update()
        {
            var index = input.SelectedSlotIndex;

            if (index >= 0 && index != _previousIndex)
            {
                _inventory.SelectSlot(index);
                _previousIndex = index;
            }
            
            BackpackActive();
        }

        private void BackpackActive()
        {
            if (!input.Backpack)
                return;
            
            backpackObj.SetActive(!backpackObj.activeSelf);
        }
    }
}
