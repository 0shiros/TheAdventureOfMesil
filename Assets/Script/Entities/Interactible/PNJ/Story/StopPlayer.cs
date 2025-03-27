using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StopPlayer : MonoBehaviour
{
    [SerializeField] private GameEvents _gameEvents;
    private PlayerMovement _playerMovement;
    private PlayerInteraction _playerInteraction;
    [SerializeField] private GameObject _playerGameObject;
    [SerializeField] private Image _blockPlayer;

    private void Awake()
    {
        _playerMovement = _playerGameObject.GetComponent<PlayerMovement>();
        _playerInteraction = _playerGameObject.GetComponent<PlayerInteraction>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!_gameEvents.hasVillageBeenAttacked)
            {
                StartCoroutine(ExitVillageBeforeAttack());
            }
        }
    }

    private IEnumerator ExitVillageBeforeAttack()
    {
        _playerMovement.canPlayerMove = false;
        _playerMovement.playerTransform.position += new Vector3(0, 0.5f, 0);
        _blockPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        _blockPlayer.gameObject.SetActive(false);
        _playerMovement.canPlayerMove = true;
    }
}
