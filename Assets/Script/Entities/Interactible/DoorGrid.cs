using UnityEngine;

public class DoorGrid : MonoBehaviour
{
    private Collider2D _collider2D;
    private Animator _animator;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _collider2D.isTrigger = false;
            _animator.SetBool("IsPlayerEnter", true);
        }
    }
}
