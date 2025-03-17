using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider _healthbar;
    private PlayerCharacteristics _playerCharacteristics;

    private void Awake()
    {
        _playerCharacteristics = GetComponent<PlayerCharacteristics>();
        HealthBar();
    }
    
    public void HealthBar()
    {
        _healthbar.maxValue = _playerCharacteristics._maxHealth;
        _healthbar.value = _playerCharacteristics._currentHealth;
    }
}
