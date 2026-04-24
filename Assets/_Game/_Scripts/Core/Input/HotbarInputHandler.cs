using UnityEngine;
using UnityEngine.InputSystem;

namespace _Game._Scripts.Core.Input
{
    internal class HotbarInputHandler
    {
        public int SelectedIndex { get; private set; } = -1;

        public void Process(InputAction scrollAction, InputAction hotbarAction)
        {
            var scroll = scrollAction.ReadValue<Vector2>().y;

            if (scroll > 0) SelectedIndex--;
            else if (scroll < 0) SelectedIndex++;

            if (hotbarAction.WasPressedThisFrame())
                SelectedIndex = ReadHotbarIndex(hotbarAction);
        }
        
        public void Clamp(int maxExclusive)
        {
            if (maxExclusive <= 0) return;
    
            if (SelectedIndex < 0)
                SelectedIndex = 0;
            else if (SelectedIndex >= maxExclusive)
                SelectedIndex = maxExclusive - 1;
        }

        private static int ReadHotbarIndex(InputAction action)
        {
            var path = action.activeControl?.path;
            if (string.IsNullOrEmpty(path)) return -1;

            return path[^1] switch
            {
                '1' => 0,
                '2' => 1,
                '3' => 2,
                '4' => 3,
                '5' => 4,
                _ => -1
            };
        }
    }
}
