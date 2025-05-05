using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    [Header("References")]
    private PlayerAttack _playerAttack;
    private Transform _playerTransform;
    private PlayerPotion _playerPotion;
    private PlayerCharacteristics _playerCharacteristics;
    private PlayerBar _playerBar;
    [SerializeField] private LayerMask _interactionLayer;

    [Header("UI")]
    [SerializeField] private GameObject _interactableText;
    private TextMeshProUGUI _interactionText;

    private void Awake()
    {
        _playerAttack = GetComponent<PlayerAttack>();
        _playerTransform = GetComponent<Transform>();
        _playerPotion = GetComponent<PlayerPotion>();
        _playerCharacteristics = GetComponent<PlayerCharacteristics>();
        _playerBar = GetComponent<PlayerBar>();
        _interactionText = _interactableText.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        DirectionLook();
    }

    private void DirectionLook()
    {
        RaycastHit2D hit = Physics2D.Raycast(_playerTransform.position, _playerAttack.attackDirection, 1f, _interactionLayer);

        Debug.DrawRay(_playerTransform.position, _playerAttack.attackDirection, Color.red);

        if (hit.collider)
        {
            switch (hit.collider.tag)
            {
                case "PNJQuest":
                    Quest quest = hit.collider.GetComponent<Quest>();

                    if(Input.GetKeyDown(KeyCode.Q))
                    {
                        quest.CurrentCompletionQuest();
                    }

                    break;

                case "SlimonPotion":

                    Interactions potionInteraction = hit.collider.GetComponent<Interactions>();

                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        Interact(potionInteraction._interactionMessage);
                        _playerPotion.ResetPotionNumber();
                        _playerCharacteristics.currentHealth = _playerCharacteristics.maxHealth;
                        _playerBar.UpdateHealthBar();
                    }

                    break;

                default:

                    Interactions interactions = hit.collider.GetComponent<Interactions>();

                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        Interact(interactions._interactionMessage);
                    }

                    break;
            }
        }
        else
        {
            _interactableText.SetActive(false);
        }
    }

    public void Interact(string message)
    {
        if (!_interactableText.activeSelf)
        {
            _interactableText.SetActive(true);
            _interactionText.text = message;
        }
        else
        {
            _interactableText.SetActive(false);
        }
    }

    
}
