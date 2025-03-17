using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBar : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Slider _staminaBar;
    [HideInInspector] public PlayerCharacteristics playerCharacteristics;

    [Header("StaminaSettings")]
    [SerializeField] private float _staminaRegenTime = 2.5f;
    public float _staminaDelay = 1f;
    public bool isRegen = false;

    private void Awake()
    {
        playerCharacteristics = GetComponent<PlayerCharacteristics>();
        HealthBar();
        StaminaBar();
    }       

    public void HealthBar()
    {
        _healthBar.maxValue = playerCharacteristics.maxHealth;
        _healthBar.value = playerCharacteristics.currentHealth;
    }

    public void StaminaBar()
    {
        _staminaBar.maxValue = playerCharacteristics.maxStamina;
        _staminaBar.value = playerCharacteristics.currentStamina;
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

                StaminaBar(); 

                yield return new WaitForSeconds(1f);
            }
        }

        isRegen = false;
    }
}
