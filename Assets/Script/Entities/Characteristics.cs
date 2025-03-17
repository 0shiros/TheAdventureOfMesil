using UnityEngine;

public class Characteristics : MonoBehaviour
{
    [Header("EntitesStatistics")]
    public int currentHealth;
    public int maxHealth;
    public int damage;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
