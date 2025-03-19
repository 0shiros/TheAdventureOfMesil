using UnityEngine;

public class PlayerDefense : MonoBehaviour
{ 
    public bool isDefending = false;
    public int defenseStaminaCost = 50;
      
    public void Defend()
    {
        isDefending = !isDefending;
    }
}
