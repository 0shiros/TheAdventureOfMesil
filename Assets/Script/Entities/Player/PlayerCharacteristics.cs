using UnityEngine;

public class PlayerCharacteristics : Characteristics
{
    [SerializeField] public int currentStamina;
    [SerializeField] public int maxStamina;
    [SerializeField] public int regenStamina = 50;
    [SerializeField] public int currentExperience;
    [SerializeField] public int maxExperience;
    [SerializeField] public int lvl = 1;
}
