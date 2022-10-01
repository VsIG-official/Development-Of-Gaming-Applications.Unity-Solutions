using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private Transform _cameraTransform;
	[SerializeField]
	private float _playerSpeed = 2.0f;
	[SerializeField]
	private float _jumpHeight = 1.0f;
	private CharacterController _controller;
	private PlayerMovement _playerMovement;
	private Vector3 _playerVelocity;

	private void Awake()
	{
		_playerMovement = new();
		_controller = gameObject.GetComponent<CharacterController>();
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
		var isOnGround = _controller.isGrounded;
		if (isOnGround && _playerVelocity.y < 0)
		{
			_playerVelocity.y = 0f;
		}

		Vector2 movement = 
			_playerMovement.Player.Movement.ReadValue<Vector2>();
		Vector3 controllerMovement = new(movement.x, 0, movement.y);
		controllerMovement = 
			_cameraTransform.forward * controllerMovement.z +
			_cameraTransform.right * controllerMovement.x;
		controllerMovement.y = 0f;

		_controller.Move(_playerSpeed * Time.deltaTime * controllerMovement);

		if (_playerMovement.Player.Jump.triggered && isOnGround)
		{
			_playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * Physics.gravity.y);
		}

		_playerVelocity.y += Physics.gravity.y * Time.deltaTime;
		_controller.Move(_playerVelocity * Time.deltaTime);
	}
}
