using TMPro;
using UnityEngine;

public class BeginAdventure : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _slimon;
    [SerializeField] private GameObject _slimonPotion;
    [SerializeField] private string[] _Dialogues;
    [SerializeField] private GameObject _interactionsGameObject;
    private PlayerMovement _playerMovement;
    private TextMeshProUGUI _interactions;

    private int _index = 0;
    private bool _hasTrigger = false;

    private void Awake()
    {
        _interactions = _interactionsGameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (_hasTrigger)
        { 
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (_index < _Dialogues.Length)
                {
                    _interactions.text = _Dialogues[_index];
                    _index++;
                }
                else
                {
                    _interactionsGameObject.SetActive(false);
                    _slimon.SetActive(false);
                    _slimonPotion.SetActive(true);
                    _playerMovement._canPlayerMove = true;
                    gameObject.SetActive(false);
                }
            }
        }         
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _playerMovement = collision.GetComponent<PlayerMovement>();
        }
        
        _playerMovement._canPlayerMove = false;    
        FirstDialogues();
    }

    private void FirstDialogues()
    {
        _interactionsGameObject.SetActive(true);
        _interactions.text = _Dialogues[_index];
        _index++;
        _hasTrigger = true;
    }    
}
