namespace _Game._Scripts.Features.Inventory.Slot
{
    public class SlotSelector
    {
        private readonly SlotView[] _slots;
        private int _selectedIndex = -1;

        public SlotView SelectedSlot
        {
            get
            {
                if (_selectedIndex < 0 || _selectedIndex >= _slots.Length)
                    return null;
                return _slots[_selectedIndex];
            }
        }

        public SlotSelector(SlotView[] slots)
        {
            _slots = slots;
        }

        public void Select(int index)
        {
            if (index < 0 || index >= _slots.Length)
                return;

            DeselectCurrent();
            _slots[index].Select();
            _selectedIndex = index;
        }

        public void DeselectCurrent() => 
            SelectedSlot?.Deselect();
    }
}
