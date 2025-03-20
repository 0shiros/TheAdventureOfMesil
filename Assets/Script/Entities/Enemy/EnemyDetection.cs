using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private Animator _enemyAnimator;
    private EnemyPattern _enemyPattern;
    private Transform _enemyTransform;
    [SerializeField] private Camera _cam;
    private Transform _camTransform;


    private void Awake()
    {
        _enemyPattern = GetComponentInParent<EnemyPattern>();
        _enemyAnimator = GetComponentInParent<Animator>();
        _enemyTransform = GetComponentInParent<Transform>();
        _camTransform = _cam.GetComponent<Transform>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 cameraPosition = _camTransform.position;

            float cameraLeftLimit = cameraPosition.x - (_cam.orthographicSize * _cam.aspect);
            float cameraRightLimit = cameraPosition.x + (_cam.orthographicSize * _cam.aspect);
            float cameraTopLimit = cameraPosition.y + _cam.orthographicSize;
            float cameraBottomLimit = cameraPosition.y - _cam.orthographicSize;

            if (_enemyTransform.position.x > cameraLeftLimit && _enemyTransform.position.x < cameraRightLimit && _enemyTransform.position.y > cameraBottomLimit && _enemyTransform.position.y < cameraTopLimit)
            {
                _enemyPattern.FollowPlayer();
                _enemyAnimator.SetBool("isFollowing", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _enemyAnimator.SetBool("isFollowing", false);
        }
    }
}
