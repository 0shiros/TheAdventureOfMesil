using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PlayerPotion : MonoBehaviour
{
    [SerializeField] private float _healthPotionPercentage = 0.3f;
    [SerializeField] private int _potionCount = 3;
    [SerializeField] private int _maxPotionCount = 3;
    [SerializeField] private GameObject[] _potions;

    private PlayerCharacteristics _playerCharacteristics;
    private PlayerBar _playerBar;

    private void Awake()
    {
        _playerCharacteristics = GetComponent<PlayerCharacteristics>();
        _playerBar = GetComponent<PlayerBar>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UsePotion();
        }
    }

    public void UsePotion()
    {
        if(_potionCount > 0 && _playerCharacteristics.currentHealth < _playerCharacteristics.maxHealth)
        {
            _playerCharacteristics.currentHealth += _playerCharacteristics.maxHealth * _healthPotionPercentage;
            if(_playerCharacteristics.currentHealth > _playerCharacteristics.maxHealth)
            {
                _playerCharacteristics.currentHealth = _playerCharacteristics.maxHealth;
            }
            _playerBar.UpdateHealthBar();
            _potionCount--;
            UIPotion();
        }
    }

    public void ResetPotionNumber()
    {
        _potionCount = _maxPotionCount;
        UIPotion();
    }

    public void AddPotion()
    {
        if(_maxPotionCount < 5)
        {
            _maxPotionCount++;
            _potionCount = _maxPotionCount;
            UIPotion();
        }        
    }

    public void UIPotion()
    {
        for(int i = 0; i < _maxPotionCount; i++)
        {
            if(i < _potionCount)
            {
                _potions[i].SetActive(true);
            }
            else
            {
                _potions[i].SetActive(false);
            }
        }
    }
}
