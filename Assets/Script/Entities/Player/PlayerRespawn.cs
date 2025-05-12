using UnityEngine;

public class PlayerRespawn : MonoBehaviour 
{    
    public static PlayerRespawn instance { get; private set; }

    [Header("References")]
    private Transform _playerTransform;
    private PlayerBar _playerBar;
    private PlayerCharacteristics _playerCharacteristics;

    public Vector3 _respawnPosition;
    [SerializeField] private Camera _camera;

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
    }
}
