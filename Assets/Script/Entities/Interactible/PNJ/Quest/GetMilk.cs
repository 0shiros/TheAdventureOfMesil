using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetMilk : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private QuestSlimeDoc _questSlimeDoc;
    [SerializeField] private Image _questDialogues;
    [SerializeField] private TextMeshProUGUI _questDialoguesText;
    [SerializeField] private string _dialogue;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(_questSlimeDoc._hasPlayerTakeQuest && !_questSlimeDoc._hasPlayerFinishQuest)
        {
            SpeakCow();
        }
        else
        {
            return;
        }
    }

    private void SpeakCow()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !_questDialogues.gameObject.activeSelf)
        {
            _playerMovement.canPlayerMove = false;
            _questDialoguesText.text = _dialogue;
            _questDialogues.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Q) && _questDialogues.gameObject.activeSelf)
            {
                _questDialogues.gameObject.SetActive(false);
                _questSlimeDoc._interrogationMarkUncomplete.SetActive(false);
                _questSlimeDoc._interrogationMarkComplete.SetActive(true);
                _playerMovement.canPlayerMove = true;
            }
        }
    }
}
