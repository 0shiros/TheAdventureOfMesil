using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StopPlayer : MonoBehaviour
{
    [SerializeField] private GameEvents _gameEvents;
    private PlayerMovement _playerMovement;
    [SerializeField] private GameObject _playerGameObject;
    [SerializeField] private Vector3 _playerKnockback;
    [SerializeField] private GameObject _interaction;
    [SerializeField] private string _interactionTextValue;
    private TextMeshProUGUI _interactionText;

    private void Awake()
    {
        _playerMovement = _playerGameObject.GetComponent<PlayerMovement>();
        _interactionText = _interaction.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!_gameEvents.hasVillageBeenAttacked)
            {
                StartCoroutine(ExitVillageBeforeAttack(_interactionTextValue));
            }
        }
    }

    private IEnumerator ExitVillageBeforeAttack(string dialogueInteraction)
    {
        _playerMovement.canPlayerMove = false;
        _playerMovement.playerTransform.position += _playerKnockback;
        _interaction.SetActive(true);
        _interactionText.text = dialogueInteraction;
        yield return new WaitForSeconds(2f);
        _interaction.SetActive(false);
        _playerMovement.canPlayerMove = true;
    }
}
