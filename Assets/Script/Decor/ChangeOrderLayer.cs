using UnityEngine;

public class ChangeOrderLayer : MonoBehaviour
{
    private Transform _playerTransform;
    private Transform _decorTransform;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _offset;

    private void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _decorTransform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        SwitchRenderer();
    }

    private void SwitchRenderer()
    {
        if (_playerTransform.position.y + _offset > _decorTransform.position.y)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 3;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }
}
