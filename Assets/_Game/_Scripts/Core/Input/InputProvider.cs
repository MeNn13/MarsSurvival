using UnityEngine;

namespace _Game._Scripts.Core.Input
{
    public class InputProvider : MonoBehaviour
    {
        [Header("Player Input Value")]
        [SerializeField] private Vector2 move;
        [SerializeField] private bool leftClick;
        [SerializeField] private bool aiming;
        [SerializeField] private bool jump;
        [SerializeField] private bool sprint;
        [SerializeField] private bool interact;
        [SerializeField] private Vector2 look;
        [SerializeField] private bool backpack;

        private Input_Actions _input;
        private readonly HotbarInputHandler _hotbarHandler = new();

        public Vector2 Move => move;
        public bool LeftClick => leftClick;
        public bool Jump => jump;
        public bool Interact => interact;
        public int SelectedSlotIndex
        {
            get
            {
                _hotbarHandler.Clamp(5);
                return _hotbarHandler.SelectedIndex;
            }
        }
        public bool Backpack => backpack;

        private void OnEnable()
        {
            _input = new Input_Actions();
            _input.Enable();
        }

        private void OnDestroy()
        {
            _input.Disable();
            _input = null;
        }

        private void Update()
        {
            ReadMovement();
            ReadActions();
            _hotbarHandler.Process(_input.Player.Scroll, _input.Player.HotbarSlot);
        }
        
        private void ReadMovement()
        {
            var input = _input.Player;
            move = input.Move.ReadValue<Vector2>();
            look = input.Look.ReadValue<Vector2>();
        }

        private void ReadActions()
        {
            var input = _input.Player;
            jump = input.Jump.WasPressedThisFrame();
            interact = input.Interact.IsPressed();
            leftClick = input.Attack.IsPressed();
            sprint = input.Sprint.IsPressed();
            backpack = input.Backpack.WasPressedThisFrame();
        }
    }
}
