using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlockPlayer : MonoBehaviour
{
    [SerializeField] private GameEvents _gameEvents;
    private PlayerMovement _playerMovement;
    [SerializeField] private GameObject _playerGameObject;
    [SerializeField] private Image _blockPlayer;
    [SerializeField] private Vector3 _playerKnockback;

    private void Awake()
    {
        _playerMovement = _playerGameObject.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!_gameEvents.hasPlayerKilledFirstBoss)
            {
                StartCoroutine(ExitVillageBeforeAttack());
            }
        }
    }

    private IEnumerator ExitVillageBeforeAttack()
    {
        _playerMovement.canPlayerMove = false;
        _playerMovement.playerTransform.position += _playerKnockback;
        _blockPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        _blockPlayer.gameObject.SetActive(false);
        _playerMovement.canPlayerMove = true;
    }
}
