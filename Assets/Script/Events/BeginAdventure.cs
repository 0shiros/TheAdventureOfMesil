using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BeginAdventure : MonoBehaviour
{
    [SerializeField] private Image _slimon;
    [SerializeField] private TextMeshProUGUI _slimonDialogues;
    [SerializeField] private TextMeshProUGUI _choice1;
    [SerializeField] private TextMeshProUGUI _choice2;
    [SerializeField] private string[] _dialogues;
    private int _currentDialogueIndex = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
        }
    }

    private IEnumerator ShowNextDialogue()
    {
        while (_currentDialogueIndex < _dialogues.Length)
        {
            _slimonDialogues.text = _dialogues[_currentDialogueIndex];

            while (!Input.GetKeyDown(KeyCode.Q))
            {
                yield return null;
            }

            yield return new WaitForSeconds(0.2f);

            _currentDialogueIndex++;
        }
    }
}
