using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference _inputActionReference;
    [SerializeField] private float _playerSpeed = 5f;

    public Vector2 PlayerInput => _inputActionReference.action.ReadValue<Vector2>();
    //public Vector2 playerInput2 => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    private Vector2 _lastPlayerInput;
    private Rigidbody2D _rigidbody2d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _lastPlayerInput = PlayerInput.normalized;
    }

    private void FixedUpdate()
    {
        _rigidbody2d.linearVelocity = _lastPlayerInput * _playerSpeed;
    }
}
