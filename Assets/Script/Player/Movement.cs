using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 5f;
    private Transform _playerTransform;

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
        Vector2 movementInput = Vector2.zero;

        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        _playerTransform.position += (Vector3)movementInput.normalized * _playerSpeed * Time.deltaTime;
    }
}
