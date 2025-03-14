using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("References")]
    private Transform _playerTransform;
    private Movement _playerMovement;

    [Header("Attack Settings")]
    [SerializeField] private Vector2 _attackRange;
    private Vector2 _playerDirection;
    [SerializeField] private LayerMask _enemyLayer;

    private void Awake()
    {
        _playerMovement = GetComponent<Movement>();
        _playerTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        BasicAttack();
    }

    private void BasicAttack()
    {
        _playerDirection = _playerMovement._movementInput.normalized;
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(_playerTransform.position + (Vector3)_playerDirection * 0.25f, _attackRange, 0, _enemyLayer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(hitEnemies.Length > 0)
            {
                Debug.Log("Hit Enemy");
            }
        }
    }

    //public void OnDrawGizmos()
    //{         
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(_playerTransform.position + (Vector3)_playerDirection * 0.25f, _attackRange);
    //}
}
