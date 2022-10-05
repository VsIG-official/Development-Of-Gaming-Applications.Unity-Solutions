using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private Transform _cameraTransform;
	[SerializeField]
	private float _playerSpeed = 5;
	[SerializeField]
	private float _jumpHeight = 1.5f;
	[SerializeField]
	private float _fallSpeed = -3f;

	private CharacterController _controller;
	private PlayerMovement _playerMovement;
	private Vector3 _playerVelocity;

	private void Awake()
	{
		_controller = GetComponent<CharacterController>();
		_playerMovement = new();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void OnEnable()
	{
		_playerMovement.Enable();
	}

	private void OnDisable()
	{
		_playerMovement.Disable();
	}

	void Update()
	{
		var isGrounded = _controller.isGrounded;
		if (_playerVelocity.y < 0 && isGrounded)
		{
			_playerVelocity.y = 0f;
		}

		Vector2 input = 
			_playerMovement.Player.Movement.ReadValue<Vector2>();

		Vector3 movement = new(input.x, 0, input.y);
		movement = 
			_cameraTransform.forward * movement.z +
			_cameraTransform.right * movement.x;
		movement.y = 0f;

		_controller.Move(_playerSpeed * Time.deltaTime * movement);

		if (_playerMovement.Player.Jump.triggered && isGrounded)
		{
			_playerVelocity.y += Mathf.Sqrt(_jumpHeight *
				_fallSpeed * Physics.gravity.y);
		}

		_playerVelocity.y += Physics.gravity.y * Time.deltaTime;
		_controller.Move(_playerVelocity * Time.deltaTime);
	}
}
