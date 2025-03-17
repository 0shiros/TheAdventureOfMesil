using UnityEngine;

public class PlayerRespawn : MonoBehaviour 
{    
    public static PlayerRespawn instance { get; private set; }

    private Transform _playerTransform;

    private void Awake()
    {
        instance = this;
        _playerTransform = GetComponent<Transform>();
    }

    public void Respawn()
    {
        gameObject.SetActive(true);
        _playerTransform.position = new Vector3(3, 3, 0);
    }
}
