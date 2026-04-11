using UnityEngine;

namespace _Game._Scripts.Features.Player.Movement
{
    public interface IMovement
    {
        void Initialize(Transform groundCheck, SpriteRenderer spriteRenderer, Rigidbody2D rb);
        void Move(float speed, float moveX);
        void Jump(float jumpForce);
    }
}
