using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _player;
    private EnemyPattern _enemyPattern;
    private EnemyCharacteristics _enemyCharacteristics;
    private Rigidbody2D _enemyRb;
    private Rigidbody2D _playerRb;
    private Renderer _playerRenderer;
    private PlayerCharacteristics _playerCaracteristics;
    private PlayerBar _playerBar;
    private PlayerDefense _playerDefense;

    [Header("AttackSettings")]
    [SerializeField] private float _playerKnockback;

    private void Awake()
    {
        _enemyPattern = GetComponent<EnemyPattern>();
        _enemyCharacteristics = GetComponent<EnemyCharacteristics>();
        _enemyRb = GetComponent<Rigidbody2D>();
        _playerRb = _player.GetComponent<Rigidbody2D>();
        _playerRenderer = _player.GetComponent<Renderer>();
        _playerCaracteristics = _player.GetComponent<PlayerCharacteristics>();
        _playerBar = _player.GetComponent<PlayerBar>();
        _playerDefense = _player.GetComponent<PlayerDefense>();
    }

    private IEnumerator AttackEffect()
    {
        _playerCaracteristics.TakeDamage(_enemyCharacteristics.damage);
        SFXManager.instance.PlaySFX("Rise");
        _playerBar.UpdateHealthBar();
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
            if(!_playerDefense.isDefending)
            {
                StartCoroutine(AttackEffect());                
            }
            else
            {
                _enemyRb.AddForce(-_enemyPattern._enemyDirection * _playerKnockback, ForceMode2D.Impulse);
            }
        }
    }
}
