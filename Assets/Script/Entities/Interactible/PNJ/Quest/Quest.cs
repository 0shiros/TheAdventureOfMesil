using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private PlayerMovement _playerMovement;
    private PlayerCharacteristics _playerCharacteristics;
    [SerializeField] private GameObject _exclamationMark;
    public GameObject _interrogationMarkUncomplete;
    public GameObject _interrogationMarkComplete;
    [SerializeField] private string[] _questDialogue;
    [SerializeField] private Image _dialogueQuest;
    [SerializeField] private TextMeshProUGUI _dialogueQuestText;
    [SerializeField] private int _questExperience;
    public bool _hasPlayerTakeQuest = false;
    public bool _hasPlayerFinishQuest = false;

    private void Awake()
    {
        _playerMovement = _player.GetComponent<PlayerMovement>();
        _playerCharacteristics = _player.GetComponent<PlayerCharacteristics>();
    }

    public void CurrentCompletionQuest()
    {
        if (_exclamationMark.activeSelf)
        {
            TakeQuest();
        }
        else if (_interrogationMarkUncomplete.activeSelf) 
        { 
            QuestUncomplete();
        }
        else if (_interrogationMarkComplete.activeSelf)
        {
            QuestComplete();
        }
    }

    private void TakeQuest()
    {
        if (!_dialogueQuest.gameObject.activeSelf)
        {
            _playerMovement.canPlayerMove = false;
            _dialogueQuestText.text = _questDialogue[0];
            _dialogueQuest.gameObject.SetActive(true);
            _hasPlayerTakeQuest = true;
        }
        else
        {
            _dialogueQuest.gameObject.SetActive(false);
            _playerMovement.canPlayerMove = true;
            _exclamationMark.SetActive(false);
            _interrogationMarkUncomplete.SetActive(true);
        }        
    }

    private void QuestUncomplete()
    {
        if (!_dialogueQuest.gameObject.activeSelf)
        {
            _playerMovement.canPlayerMove = false;
            _dialogueQuestText.text = _questDialogue[1];
            _dialogueQuest.gameObject.SetActive(true);
        }
        else
        {
            _dialogueQuest.gameObject.SetActive(false);
            _playerMovement.canPlayerMove = true;
        }
    }

    private void QuestComplete()
    {
        if (!_dialogueQuest.gameObject.activeSelf)
        {
            _playerMovement.canPlayerMove = false;
            _dialogueQuestText.text = _questDialogue[2];
            _dialogueQuest.gameObject.SetActive(true);
        }
        else
        {
            _dialogueQuest.gameObject.SetActive(false);
            _playerMovement.canPlayerMove = true;
            _playerCharacteristics.GainExperience(_questExperience);
            SFXManager.instance.PlaySFX("GetExperience");
            _interrogationMarkComplete.gameObject.SetActive(false);
            _hasPlayerFinishQuest = true;
            gameObject.tag = "Untagged";
        }
    }
}
