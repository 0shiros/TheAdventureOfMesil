using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 5f;
    [HideInInspector] public Transform playerTransform;
    [HideInInspector] public Vector2 _movementInput = Vector2.zero;
    private PlayerDefense _playerDefense;
    public bool canPlayerMove = true;

    private void Awake()
    {
        playerTransform = GetComponent<Transform>();
        _playerDefense = GetComponent<PlayerDefense>();
    }

    private void FixedUpdate()
    {
        if (canPlayerMove && !_playerDefense.isDefending)
        {
            Move();
        }
    }

    private void Move()
    {
        _movementInput.x = Input.GetAxisRaw("Horizontal");
        _movementInput.y = Input.GetAxisRaw("Vertical");

        playerTransform.position += (Vector3)_movementInput.normalized * _playerSpeed * Time.deltaTime;
    }
}
