using UnityEngine;

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

    public void GainExperience(int experience)
    {
        if(level < maxLevel)
        {
            currentExperience += experience;

            while (level < maxLevel && currentExperience >= maxExperiences[level])
            {
                currentExperience -= maxExperiences[level];
                level++;
                if(level >= maxLevel)
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
}
