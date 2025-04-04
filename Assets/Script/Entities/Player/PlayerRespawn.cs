using UnityEngine;

public class PlayerRespawn : MonoBehaviour 
{    
    public static PlayerRespawn instance { get; private set; }

    [Header("References")]
    private Transform _playerTransform;
    private PlayerBar _playerBar;
    private PlayerCharacteristics _playerCharacteristics;

    [SerializeField] private Vector3 _respawnPosition;
    [SerializeField] private Camera _camera;
    [SerializeField] private Animator[] _doorGridAnimators;

    private void Awake()
    {
        instance = this;
        _playerTransform = GetComponent<Transform>();
        _playerBar = GetComponent<PlayerBar>();
        _playerCharacteristics = GetComponent<PlayerCharacteristics>();
    }

    public void Respawn()
    {
        gameObject.SetActive(true);
        _playerTransform.position = _respawnPosition;
        _camera.transform.position = new Vector3(0, 0, -10);
        _playerCharacteristics.currentHealth = _playerCharacteristics.maxHealth;
        _playerBar.UpdateHealthBar();
        for(int i = 0; i < _doorGridAnimators.Length; i++)
        {
            Collider2D[] _doorGrid = _doorGridAnimators[i].GetComponentsInChildren<Collider2D>();
            _doorGridAnimators[i].SetBool("IsPlayerEnter", false);
            _doorGrid[i].isTrigger = true;
        }
    }
}
