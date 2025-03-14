using UnityEngine;

public class Pattern : MonoBehaviour
{
    private Transform _enemyTransform;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private Transform _playerTransform;

    private void Awake()
    {
        _enemyTransform = GetComponent<Transform>();
    }

    private void Update()
    {        

    }    

    public void FollowPlayer()
    {
        _enemyTransform.position = Vector3.MoveTowards(_enemyTransform.position, _playerTransform.position, _enemySpeed * Time.deltaTime);
    }
}
