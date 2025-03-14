using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    
    private Pattern _pattern;

    private void Awake()
    {
        _pattern = GetComponentInParent<Pattern>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _pattern.FollowPlayer();
        }
    }
}
