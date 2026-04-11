using _Game._Scripts.Core.Input;
using _Game._Scripts.Features.Player.Movement;
using UnityEngine;
using Zenject;

namespace _Game._Scripts.Features.Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpForce = 3f;

        [Header("Unity Settings")]
        [SerializeField] private Transform groundCheck;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private InputProvider input;
        
        private IMovement _movement;
        
        [Inject]
        public void Construct(IMovement movement)
        {
            _movement =  movement;
        }

        private void Start()
        {
            _movement.Initialize(groundCheck, spriteRenderer, rb);
        }

        private void Update()
        {
            if (input.GetMove.magnitude >= .1f)
            {
                _movement.Move(speed, input.GetMove.x);
            }
            
            if (input.Jump)
                _movement.Jump(jumpForce);
        }
    }
}
