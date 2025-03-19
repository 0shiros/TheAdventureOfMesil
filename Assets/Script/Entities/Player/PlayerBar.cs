using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBar : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Slider _staminaBar;
    [HideInInspector] public PlayerCharacteristics playerCharacteristics;
    private PlayerUICharacteristics _playerUICharacteristics;

    [Header("StaminaSettings")]
    [SerializeField] private float _staminaRegenTime = 2.5f;
    public float _staminaDelay = 1f;
    public bool isRegen = false;

    private void Awake()
    {
        playerCharacteristics = GetComponent<PlayerCharacteristics>();
        _playerUICharacteristics = GetComponent<PlayerUICharacteristics>();
        UpdateHealthBar();
        UpdateStaminaBar();
    }       

    public void UpdateHealthBar()
    {
        _healthBar.maxValue = playerCharacteristics.maxHealth;
        _healthBar.value = playerCharacteristics.currentHealth;
        _playerUICharacteristics.UpdateStatisticsUI();
    }

    public void UpdateStaminaBar()
    {
        _staminaBar.maxValue = playerCharacteristics.maxStamina;
        _staminaBar.value = playerCharacteristics.currentStamina;
        _playerUICharacteristics.UpdateStatisticsUI();
    }

    public IEnumerator StaminaRegen()
    {
        isRegen = true;

        if(Time.time - _staminaDelay > _staminaRegenTime)
        {
            if(playerCharacteristics.currentStamina < playerCharacteristics.maxStamina)
            {
                playerCharacteristics.currentStamina += playerCharacteristics.regenStamina;

                if(playerCharacteristics.currentStamina > playerCharacteristics.maxStamina)
                {
                    playerCharacteristics.currentStamina = playerCharacteristics.maxStamina;
                }

                UpdateStaminaBar(); 

                yield return new WaitForSeconds(1f);
            }
        }

        isRegen = false;
    }
}
