using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlimonFishing : MonoBehaviour
{
    [SerializeField] private GameEvents _gameEvents;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _playerFishing;
    [SerializeField] private GameObject _area3;
    [SerializeField] private GameObject _area3Bis;
    [SerializeField] private Image _blackScreen;
    [SerializeField] private Image _slimonFish;
    [SerializeField] private TextMeshProUGUI _choiceText;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private string[] _dialogues;
    private int _currentDialogueIndex = 0;

    public void ChoiceFishing()
    {
        _slimonFish.gameObject.SetActive(true);
    }

    public void WantToFish()
    {
        _slimonFish.gameObject.SetActive(false);
        StartCoroutine(FishingTime());
    }

    public void DoesntWantToFish()
    {
        _slimonFish.gameObject.SetActive(false);
    }

    private IEnumerator FishingTime()
    {
        _blackScreen.gameObject.SetActive(true);
        _choiceText.gameObject.SetActive(false);
        _player.SetActive(false);
        _playerFishing.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _slimonFish.gameObject.SetActive(true);
        _dialogueText.gameObject.SetActive(true);
        _blackScreen.gameObject.SetActive(false);
        StartCoroutine(ShowNextDialogue());
    }

    private IEnumerator ShowNextDialogue()
    {
        while (_currentDialogueIndex < _dialogues.Length)
        {
            _dialogueText.text = _dialogues[_currentDialogueIndex];

            while (!Input.GetKeyDown(KeyCode.Q))
            {
                yield return null;
            }

            yield return new WaitForSeconds(0.2f);

            _currentDialogueIndex++;
        }

        StartCoroutine(AttackOnVillage());
    }

    private IEnumerator AttackOnVillage()
    {
        _blackScreen.gameObject.SetActive(true);
        _playerFishing.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        _slimonFish.gameObject.SetActive(false);
        _player.SetActive(true);
        _blackScreen.gameObject.SetActive(false);
        gameObject.SetActive(false);
        _gameEvents.hasVillageBeenAttacked = true;
        _area3.SetActive(false);
        _area3Bis.SetActive(true);
    }
}
