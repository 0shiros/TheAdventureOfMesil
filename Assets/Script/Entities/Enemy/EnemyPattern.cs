using UnityEngine;

public class EnemyPattern : MonoBehaviour
{
    private Transform _enemyTransform;
    [SerializeField] private float _enemySpeed = 2f;
    [SerializeField] private Transform _playerTransform;
    [HideInInspector] public Vector2 _enemyDirection;

    private void Awake()
    {
        _enemyTransform = GetComponent<Transform>();
    }        

    public void FollowPlayer()
    {
        Vector3 previousPosition = _enemyTransform.position;
        _enemyTransform.position = Vector3.MoveTowards(_enemyTransform.position, _playerTransform.position, _enemySpeed * Time.deltaTime);
        Vector3 _enemyLook = _enemyTransform.position - previousPosition;

        if (_enemyLook.x > 0)
        {
            _enemyTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_enemyLook.x < 0)
        {
            _enemyTransform.rotation = Quaternion.Euler(0, 180, 0);
        }

        _enemyDirection = (_playerTransform.position - _enemyTransform.position).normalized;
    }
}
