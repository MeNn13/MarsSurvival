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
        [SerializeField] private bool inventory;

        private Input_Actions _input;

        public Vector2 GetMove => move;
        public bool LeftClick => leftClick;
        public bool Jump => jump;
        public bool Interact => interact;

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

        private void Update() => UpdateInputState();

        private void UpdateInputState()
        {
            var input = _input.Player;
            
            MoveInput(input.Move.ReadValue<Vector2>());
            JumpInput(input.Jump.WasPressedThisFrame());
            InteractInput(input.Interact.IsPressed());
            //LeftClickInput(input.LeftClick.IsPressed());
        }
        
        private void JumpInput(bool newValue) => jump = newValue;
        private void MoveInput(Vector2 newDirection) => move = newDirection;
        private void InteractInput(bool newValue) => interact = newValue;
        private void LeftClickInput(bool newValue) => leftClick = newValue;
    }
}
