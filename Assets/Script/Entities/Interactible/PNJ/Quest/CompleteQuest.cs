using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompleteQuest : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Quest _questSlimeDoc;
    [SerializeField] private Image _questDialogues;
    [SerializeField] private TextMeshProUGUI _questDialoguesText;
    [SerializeField] private string _dialogue;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(_questSlimeDoc._hasPlayerTakeQuest && !_questSlimeDoc._hasPlayerFinishQuest)
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
            _questSlimeDoc._interrogationMarkUncomplete.SetActive(false);
            _questSlimeDoc._interrogationMarkComplete.SetActive(true);
            _playerMovement.canPlayerMove = true;
        }        
    }
}
