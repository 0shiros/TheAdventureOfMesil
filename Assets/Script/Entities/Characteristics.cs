using UnityEngine;

public class Characteristics : MonoBehaviour
{
    [SerializeField] public int _currentHealth;
    [SerializeField] public int _maxHealth;
    [SerializeField] public int _damage;

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
