using UnityEngine;

public class CameraSwitchZone : MonoBehaviour
{
    private Camera _camera;
    private Transform _cameraTransform;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private EnemyPattern[] _enemyPatterns;

    private void Awake()
    {
        _camera = Camera.main;
        _cameraTransform = GetComponent<Transform>();
    }

    private void SwitchZone(Vector3 collisionPoint)
    {
        Vector3 cameraPosition = _camera.transform.position;

        float cameraLeftLimit = cameraPosition.x - (_camera.orthographicSize * _camera.aspect);
        float cameraRightLimit = cameraPosition.x + (_camera.orthographicSize * _camera.aspect);
        float cameraTopLimit = cameraPosition.y + _camera.orthographicSize;
        float cameraBottomLimit = cameraPosition.y - _camera.orthographicSize;

        float newCameraX = cameraPosition.x;
        float newCameraY = cameraPosition.y;

        if (collisionPoint.x < cameraLeftLimit)
        {
            newCameraX = cameraLeftLimit - (_camera.orthographicSize * _camera.aspect);
        }
        else if (collisionPoint.x > cameraRightLimit)
        {
            newCameraX = cameraRightLimit + (_camera.orthographicSize * _camera.aspect);
        }

        if (collisionPoint.y < cameraBottomLimit)
        {
            newCameraY = cameraBottomLimit - _camera.orthographicSize;
        }
        else if (collisionPoint.y > cameraTopLimit)
        {
            newCameraY = cameraTopLimit + _camera.orthographicSize;
        }

        _camera.transform.position = new Vector3(newCameraX, newCameraY, cameraPosition.z);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 collisionPoint = collision.ClosestPoint(_cameraTransform.position);
            SwitchZone(collisionPoint);
            foreach (EnemyPattern enemy in _enemyPatterns)
            {
                if (enemy != null)
                {
                    enemy.ResetEnemy();
                }
            }
        }
    }
}
