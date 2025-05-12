using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StopPlayer : MonoBehaviour
{
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
            KnockbackPlayer(_interactionTextValue);            
        }
    }

    private void KnockbackPlayer(string dialogueInteraction)
    {
        _playerMovement._canPlayerMove = false;
        _playerMovement.playerTransform.position += _playerKnockback;
        _interaction.SetActive(true);
        _interactionText.text = dialogueInteraction;
        _playerMovement._canPlayerMove = true;
    }
}
