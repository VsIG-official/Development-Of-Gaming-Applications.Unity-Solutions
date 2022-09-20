using UnityEngine;
using UnityEngine.InputSystem;

namespace Lab1
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float _movementSpeed = 5f;
		[SerializeField]
		private float _jumpSpeed = 5f;
		[SerializeField]
        private float _groundCheckRadius = 0.3f;
        [SerializeField]
        private LayerMask _groundMask;

        private Vector2 _groundCheckPos;
        private float _xMovement;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();

            var colliderRadius = GetComponent<CircleCollider2D>().radius;
            _groundCheckPos = new(0, -colliderRadius);
		}

        private void FixedUpdate()
        {
			_rb.velocity = new(_xMovement * _movementSpeed, _rb.velocity.y);
		}

        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheckPos,
                _groundCheckRadius, _groundMask);
        }

		public void Move(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
				_xMovement = context.ReadValue<Vector2>().x;
			}
		}

        public void Jump(InputAction.CallbackContext context)
        {
            if (context.performed && IsGrounded())
            {
                _rb.velocity = new(_rb.velocity.x, _jumpSpeed);
            }
        }
    }
}
