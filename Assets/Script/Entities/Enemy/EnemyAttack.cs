using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _playerKnockback;
    private EnemyPattern _enemyPattern;
    private EnemyCharacteristics _enemyCharacteristics;
    private Rigidbody2D _playerRb;
    private Renderer _playerRenderer;
    private PlayerCharacteristics _playerCaracteristics;
    private PlayerBar _playerBar;

    private void Awake()
    {
        _enemyPattern = GetComponent<EnemyPattern>();
        _enemyCharacteristics = GetComponent<EnemyCharacteristics>();
        _playerRb = _player.GetComponent<Rigidbody2D>();
        _playerRenderer = _player.GetComponent<Renderer>();
        _playerCaracteristics = _player.GetComponent<PlayerCharacteristics>();
        _playerBar = _player.GetComponent<PlayerBar>();
    }

    private IEnumerator AttackEffect()
    {
        _playerCaracteristics.TakeDamage(_enemyCharacteristics.damage);
        _playerBar.HealthBar();
        _playerRb.AddForce( _enemyPattern._enemyDirection * _playerKnockback, ForceMode2D.Impulse);
        _playerRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _playerRenderer.material.color = Color.white;
        if (!_player.activeSelf)
        {
            PlayerRespawn.instance.Respawn();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(AttackEffect());
        }
    }
}
