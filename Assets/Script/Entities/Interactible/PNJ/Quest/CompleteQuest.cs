using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompleteQuest : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Quest _quest;
    [SerializeField] private Image _questDialogues;
    [SerializeField] private TextMeshProUGUI _questDialoguesText;
    [SerializeField] private string _dialogue;
    [SerializeField] private bool _canTalk;
    [SerializeField] private bool _canTalkAgain = true;

    private void Update()
    {
        if (_canTalk)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SpeakCow();
            }
        }
        else
        {
            return;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_quest._hasPlayerTakeQuest && _canTalkAgain)
        {
            _canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_quest._hasPlayerTakeQuest)
        {
            _canTalk = false;
        }
    }

    private void SpeakCow()
    {
        if (!_questDialogues.gameObject.activeSelf)
        {
            _playerMovement.canPlayerMove = false;
            _questDialoguesText.text = _dialogue;
            _questDialogues.gameObject.SetActive(true);          
        }
        else
        {
            _questDialogues.gameObject.SetActive(false);
            _quest._interrogationMarkUncomplete.SetActive(false);
            _quest._interrogationMarkComplete.SetActive(true);
            _playerMovement.canPlayerMove = true;
            _canTalk = false;
            _canTalkAgain = false;
        }        
    }
}
