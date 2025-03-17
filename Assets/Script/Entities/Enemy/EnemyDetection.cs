using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private Animator _enemyAnimator;
    private EnemyPattern _enemyPattern;

    private void Awake()
    {
        _enemyPattern = GetComponentInParent<EnemyPattern>();
        _enemyAnimator = GetComponentInParent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _enemyPattern.FollowPlayer();
            _enemyAnimator.SetBool("isFollowingPlayer", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _enemyAnimator.SetBool("isFollowingPlayer", false);
        }
    }
}
