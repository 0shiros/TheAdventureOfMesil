using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("References")]
    private Transform _playerTransform;
    private PlayerMovement _playerMovement;
    private PlayerCharacteristics _playerCharacteristics;
    private PlayerBar _playerBar;

    [Header("Attack Settings")]
    [SerializeField] private LayerMask _enemyLayer;
    [HideInInspector] public Vector2 _attackDirection = Vector2.zero;
    private Vector2 _playerDirection;
    [SerializeField] private Vector2 _attackArea;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private float _enemyKnockback = 0.5f;
    [SerializeField] public int _basicAttackStaminaCost = 25;


    private bool _attackTriggered = false;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerTransform = GetComponent<Transform>();
        _playerCharacteristics = GetComponent<PlayerCharacteristics>();
        _playerBar = GetComponent<PlayerBar>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _attackTriggered = !_attackTriggered; 
        }

        if (!_playerBar.isRegen)
        {
            StartCoroutine(_playerBar.StaminaRegen());
        }
    }

    private void SetAttackDirection()
    {
        _playerDirection = _playerMovement._movementInput.normalized;

        if (_playerDirection.x != 0)
        {
            _attackDirection.x = Mathf.Sign(_playerDirection.x);
            _attackDirection.y = 0;
        }
        else if (_playerDirection.y != 0)
        {
            _attackDirection.y = Mathf.Sign(_playerDirection.y);
            _attackDirection.x = 0;
        }
    }

    public IEnumerator BasicAttack()
    {
        SetAttackDirection();

        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(_playerTransform.position + (Vector3)_attackDirection * _attackRange, _attackArea, 0, _enemyLayer);

        if(hitEnemies.Length > 0)
        {
            for(int i = 0; i < hitEnemies.Length; i++)
            {
                Rigidbody2D _enemyRb = hitEnemies[i].GetComponent<Rigidbody2D>();
                Renderer _enemyRenderer = hitEnemies[i].GetComponent<Renderer>();
                EnemyCharacteristics _enemyCharacteristics = hitEnemies[i].GetComponent<EnemyCharacteristics>();

                _enemyCharacteristics.TakeDamage(_playerCharacteristics.damage);
                if (!_enemyCharacteristics.gameObject.activeSelf)
                {
                    _playerCharacteristics.GainExperience(_enemyCharacteristics.grantExperience);
                }
                _enemyRb.AddForce(_attackDirection * _enemyKnockback, ForceMode2D.Impulse);
                _enemyRenderer.material.color = Color.red;
                yield return new WaitForSeconds(0.1f);
                _enemyRenderer.material.color = Color.white;
            }
        }
        
    }        

    public void OnDrawGizmos()
    {
        SetAttackDirection();

        Gizmos.color = Color.red;
        if (_attackTriggered)
        {
            Gizmos.DrawWireCube(_playerTransform.position + (Vector3)_attackDirection * _attackRange, _attackArea);
            _attackTriggered = false;
        }
    }
}
