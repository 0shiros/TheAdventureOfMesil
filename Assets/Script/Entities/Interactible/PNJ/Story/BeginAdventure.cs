using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BeginAdventure : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Image _slimon;
    [SerializeField] private TextMeshProUGUI _slimonDialogues;
    [SerializeField] private TextMeshProUGUI _choice1;
    [SerializeField] private TextMeshProUGUI _choice2;
    [SerializeField] private string[] _dialoguesPreChoice;
    [SerializeField] private string[] _dialoguesPostChoice;
    [SerializeField] private GameObject _slimonArea3bis;
    [SerializeField] private GameObject _slimonArea2;
    [SerializeField] private GameObject _badEnd;
    private int _currentDialogueIndex = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerMovement.canPlayerMove = false;
            _slimon.gameObject.SetActive(true);
            StartCoroutine(ShowNextDialogue1());
        }
    }

    private IEnumerator ShowNextDialogue1()
    {
        _currentDialogueIndex = 0;

        while (_currentDialogueIndex < _dialoguesPreChoice.Length)
        {
            _slimonDialogues.text = _dialoguesPreChoice[_currentDialogueIndex];

            while (!Input.GetKeyDown(KeyCode.Q))
            {
                yield return null;
            }

            yield return new WaitForSeconds(0.2f);

            _currentDialogueIndex++;
        }

        _slimonDialogues.gameObject.SetActive(false);
        _choice1.gameObject.SetActive(true);
    }

    private IEnumerator ShowNextDialogue2()
    {
        _currentDialogueIndex = 0;

        while (_currentDialogueIndex < _dialoguesPostChoice.Length)
        {
            _slimonDialogues.text = _dialoguesPostChoice[_currentDialogueIndex];

            while (!Input.GetKeyDown(KeyCode.Q))
            {
                yield return null;
            }

            yield return new WaitForSeconds(0.2f);

            _currentDialogueIndex++;
        }

        _slimonArea3bis.SetActive(false);
        _slimonArea2.SetActive(true);
        _playerMovement.canPlayerMove = true;
        gameObject.SetActive(false);
        _slimon.gameObject.SetActive(false);
    }

    public void AcceptChoice1()
    {
        _choice1.gameObject.SetActive(false);
        _slimonDialogues.gameObject.SetActive(true);
        StartCoroutine(ShowNextDialogue2());
    }

    public void RefuseChoice1()
    {
        _choice1.gameObject.SetActive(false);
        _choice2.gameObject.SetActive(true);
    }

    public void AcceptChoice2()
    {
        _choice2.gameObject.SetActive(false);
        _slimonDialogues.gameObject.SetActive(true);
        StartCoroutine(ShowNextDialogue2());
    }

    public void RefuseChoice2()
    {
        _choice2.gameObject.SetActive(false);
        _slimonDialogues.gameObject.SetActive(true);
        _slimonDialogues.text = "Je peux slomprendre que tu sois sleffrayé, dans ce cas nous devons sluir";
        StartCoroutine(badEnd());
    }

    private IEnumerator badEnd()
    {
        yield return new WaitForSeconds(3f);
        _slimonDialogues.gameObject.SetActive(false);
        _badEnd.SetActive(true);
    }
}
