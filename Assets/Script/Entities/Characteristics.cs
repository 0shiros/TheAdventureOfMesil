using UnityEngine;

public class Characteristics : MonoBehaviour
{
    [Header("EntitesStatistics")]
    public float currentHealth;
    public float maxHealth;
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
