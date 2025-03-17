using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _playerKnockback;
    private EnemyPattern _enemyPattern;
    private Rigidbody2D _playerRb;
    private Renderer _playerRenderer;
    private PlayerCharacteristics _playerHealth;

    private void Awake()
    {
        _playerRb = _player.GetComponent<Rigidbody2D>();
        _playerRenderer = _player.GetComponent<Renderer>();
        _enemyPattern = GetComponent<EnemyPattern>();
        _playerHealth = GetComponent<PlayerCharacteristics>();
    }

    private IEnumerator AttackEffect()
    {
        _playerHealth.TakeDamage(5);
        _playerRb.AddForce( _enemyPattern._enemyDirection * _playerKnockback, ForceMode2D.Impulse);
        _playerRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _playerRenderer.material.color = Color.white;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(AttackEffect());
            //PlayerRespawn.instance.Respawn();
        }
    }
}
