using UnityEngine;

public class EnemyPattern : MonoBehaviour
{
    private Transform _enemyTransform;
    [SerializeField] private float _enemySpeed = 2f;
    [SerializeField] private Transform _playerTransform;

    private void Awake()
    {
        _enemyTransform = GetComponent<Transform>();
    }        

    public void FollowPlayer()
    {
        Vector3 previousPosition = _enemyTransform.position;
        _enemyTransform.position = Vector3.MoveTowards(_enemyTransform.position, _playerTransform.position, _enemySpeed * Time.deltaTime);
        Vector3 direction = _enemyTransform.position - previousPosition;

        if (direction.x > 0)
        {
            _enemyTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction.x < 0)
        {
            _enemyTransform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
