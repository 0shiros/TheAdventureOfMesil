using UnityEngine;

public class PlayerRespawn : MonoBehaviour 
{    
    public static PlayerRespawn instance { get; private set; }

    [Header("References")]
    private Transform _playerTransform;
    private PlayerBar _playerBar;
    private PlayerCharacteristics _playerCharacteristics;

    [SerializeField] private Vector3 _respawnPosition;
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
        _playerCharacteristics.currentHealth = _playerCharacteristics.maxHealth;
        _playerBar.UpdateHealthBar();
        for(int i = 0; i < _doorGridAnimators.Length; i++)
        {
            _doorGridAnimators[i].SetBool("IsPlayerEnter", false);
        }
    }
}
