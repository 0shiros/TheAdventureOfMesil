using UnityEngine;

public class Characteristics : MonoBehaviour
{
    [SerializeField] public int currentHealth;
    [SerializeField] public int maxHealth;
    [SerializeField] public int damage;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
