using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _playerKnockback;
    private Rigidbody2D _playerRb;
    private PlayerAttack _playerAttack;
    private Renderer _playerRenderer;

    private void Awake()
    {
        _playerRb = _player.GetComponent<Rigidbody2D>();
        _playerAttack = _player.GetComponent<PlayerAttack>();
        _playerRenderer = _player.GetComponent<Renderer>();
    }

    private IEnumerator Attack()
    {
        _playerRb.AddForce(-_playerAttack._attackDirection * _playerKnockback, ForceMode2D.Impulse);
        _playerRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _playerRenderer.material.color = Color.white;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Attack());
            //PlayerRespawn.instance.Respawn();
        }
    }
}
