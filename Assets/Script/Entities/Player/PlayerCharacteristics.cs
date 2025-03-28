using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Statistics
{
    public int maxHealth;
    public int maxStamina;
    public int damage;
}

public class PlayerCharacteristics : Characteristics
{
    [Header("PlayerStatistics")]
    public int currentStamina;
    public int maxStamina;
    public int regenStamina = 50;
    public int level = 1;
    private int maxLevel = 20;
    public int currentExperience;
    public int[] maxExperiences;
    public List<Statistics> statistics = new();

    private PlayerUICharacteristics _playerUICharacteristics;

    private void Awake()
    {
        _playerUICharacteristics = GetComponent<PlayerUICharacteristics>();
    }

    public void GainExperience(int experience)
    {
        if(level < maxLevel)
        {
            currentExperience += experience;
            _playerUICharacteristics.UpdateStatisticsUI();

            while (level < maxLevel && currentExperience >= maxExperiences[level])
            {
                currentExperience -= maxExperiences[level];
                level++;
                UpgradeStatistics(level);
                _playerUICharacteristics.UpdateStatisticsUI();
                if (level >= maxLevel)
                {
                    currentExperience = 0;
                }
            }                    
        }
        else
        {
            currentExperience = 0;
        }           
    }

    public void UpgradeStatistics(int level)
    {
        maxHealth = statistics[level].maxHealth;
        currentHealth = maxHealth;
        maxStamina = statistics[level].maxStamina;
        currentStamina = maxStamina;
        damage = statistics[level].damage;
    }
}

//GenericPropertyJSON:{"name":"statistics","type":-1,"arraySize":21,"arrayType":"Statistics","children":[{"name":"Array","type":-1,"arraySize":21,"arrayType":"Statistics","children":[{"name":"size","type":12,"val":21},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":0},{"name":"maxStamina","type":0,"val":0},{"name":"damage","type":0,"val":0}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":100},{"name":"maxStamina","type":0,"val":200},{"name":"damage","type":0,"val":5}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":120},{"name":"maxStamina","type":0,"val":210},{"name":"damage","type":0,"val":6}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":140},{"name":"maxStamina","type":0,"val":220},{"name":"damage","type":0,"val":7}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":160},{"name":"maxStamina","type":0,"val":230},{"name":"damage","type":0,"val":8}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":180},{"name":"maxStamina","type":0,"val":240},{"name":"damage","type":0,"val":9}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":200},{"name":"maxStamina","type":0,"val":250},{"name":"damage","type":0,"val":12}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":220},{"name":"maxStamina","type":0,"val":260},{"name":"damage","type":0,"val":15}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":240},{"name":"maxStamina","type":0,"val":270},{"name":"damage","type":0,"val":18}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":260},{"name":"maxStamina","type":0,"val":280},{"name":"damage","type":0,"val":21}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":280},{"name":"maxStamina","type":0,"val":290},{"name":"damage","type":0,"val":24}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":300},{"name":"maxStamina","type":0,"val":300},{"name":"damage","type":0,"val":30}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":320},{"name":"maxStamina","type":0,"val":310},{"name":"damage","type":0,"val":36}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":340},{"name":"maxStamina","type":0,"val":320},{"name":"damage","type":0,"val":42}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":360},{"name":"maxStamina","type":0,"val":330},{"name":"damage","type":0,"val":48}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":380},{"name":"maxStamina","type":0,"val":340},{"name":"damage","type":0,"val":54}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":400},{"name":"maxStamina","type":0,"val":350},{"name":"damage","type":0,"val":60}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":420},{"name":"maxStamina","type":0,"val":360},{"name":"damage","type":0,"val":70}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":440},{"name":"maxStamina","type":0,"val":370},{"name":"damage","type":0,"val":80}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":460},{"name":"maxStamina","type":0,"val":380},{"name":"damage","type":0,"val":90}]},{"name":"data","type":-1,"children":[{"name":"maxHealth","type":0,"val":500},{"name":"maxStamina","type":0,"val":400},{"name":"damage","type":0,"val":100}]}]}]}    
