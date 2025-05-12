using System;
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
    [SerializeField] private GameObject _interactionsGameObject;
    [HideInInspector] public TextMeshProUGUI _interactionText;

    private void Awake()
    {
        _playerAttack = GetComponent<PlayerAttack>();
        _playerTransform = GetComponent<Transform>();
        _playerPotion = GetComponent<PlayerPotion>();
        _playerCharacteristics = GetComponent<PlayerCharacteristics>();
        _playerBar = GetComponent<PlayerBar>();
        _interactionText = _interactionsGameObject.GetComponentInChildren<TextMeshProUGUI>();
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
                case "Slimon":

                    SlimonFishing slimon = hit.collider.GetComponent<SlimonFishing>();
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        slimon.ChoiceFishing();
                    }

                    break;

                case "BreakRock":

                    DestroyStone stone = hit.collider.GetComponent<DestroyStone>();
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        stone.StoneChoice();
                    }
                    break;

                case "PNJQuest":

                    Quest quest = hit.collider.GetComponent<Quest>();

                    if(Input.GetKeyDown(KeyCode.Q))
                    {
                        quest.CurrentQuestState();
                        Interact(quest._currentDialogue);
                    }

                    break;

                case "ObjectQuest":

                    CompleteQuest questObject = hit.collider.GetComponent<CompleteQuest>();

                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        questObject.UpdateQuest();
                        Interact(questObject._objectDialogue);
                    }

                    break;

                case "SlimonPotion":

                    Interactions interaction = hit.collider.GetComponent<Interactions>();

                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        Interact(interaction.CurrentMessage());
                        _playerPotion.ResetPotionNumber();
                        _playerCharacteristics.currentHealth = _playerCharacteristics.maxHealth;
                        _playerBar.UpdateHealthBar();
                    }

                    break;


                default:

                    Interactions interactions = hit.collider.GetComponent<Interactions>();

                    if (Input.GetKeyDown(KeyCode.Q))
                    {                 
                        if(interactions != null)
                        {
                            Interact(interactions.CurrentMessage());
                        }                  
                    }

                    break;
            }
        }
        else
        {
            _interactionsGameObject.SetActive(false);
        }
    }

    public void Interact(string message)
    {
        if (!_interactionsGameObject.activeSelf)
        {
            _interactionsGameObject.SetActive(true);
        }
        else
        {
            _interactionsGameObject.SetActive(false);
        }

        _interactionText.text = message;
    }    
}
