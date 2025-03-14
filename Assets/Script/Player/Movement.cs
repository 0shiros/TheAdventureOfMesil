using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 5f;
    private Transform _playerTransform;
    [HideInInspector] public Vector2 _movementInput = Vector2.zero;

    private void Awake()
    {
        _playerTransform = transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _movementInput.x = Input.GetAxisRaw("Horizontal");
        _movementInput.y = Input.GetAxisRaw("Vertical");

        _playerTransform.position += (Vector3)_movementInput.normalized * _playerSpeed * Time.deltaTime;
    }
}
