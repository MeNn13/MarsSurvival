using UnityEngine;

namespace _Game._Scripts.Features.Player.Movement
{
    public class Movement : IMovement
    {
        private const float GRAVITY = -15f;
        private const float GROUND_RANGE = .1f;

        private Rigidbody2D _rb;
        private Transform _groundCheck;
        private SpriteRenderer _spriteRenderer;

        private Vector3 _velocity;
        private bool _isGrounded;

        public void Initialize(Transform groundCheck, SpriteRenderer spriteRenderer, Rigidbody2D rb)
        {
            _rb = rb;
            _groundCheck = groundCheck;
            _spriteRenderer = spriteRenderer;
        }
        
        public void Move(float speed, float moveX)
        {
            _isGrounded = Physics2D.OverlapCircle(_groundCheck.position,
                GROUND_RANGE, LayerMask.GetMask("Environment"));

            SetGravity();
            Flip(moveX);

            Vector2 move = new Vector2(moveX * speed, _rb.linearVelocity.y);
            _rb.linearVelocity = move;
        }

        public void Jump(float jumpForce)
        {
            if (_isGrounded)
                _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        private void SetGravity()
        {
            _velocity = _rb.linearVelocity;

            if (!_isGrounded)
                _velocity.y += GRAVITY * Time.fixedDeltaTime;
            else if (_rb.linearVelocity.y < 0)
                _velocity.y = 0;

            _rb.linearVelocity = _velocity;
        }

        private void Flip(float moveX)
        {
            var flipX = _spriteRenderer.flipX;

            flipX = moveX switch
            {
                > 0f when flipX => false,
                < 0f when !flipX => true,
                _ => flipX
            };

            _spriteRenderer.flipX = flipX;
        }
    }
}
