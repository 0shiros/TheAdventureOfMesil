using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlimonFishing : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _interactions;
    [SerializeField] private GameObject _choices;
    [SerializeField] private GameObject _blackscreen;
    [SerializeField] private GameObject _map3;
    [SerializeField] private GameObject _map3Bis;
    [SerializeField] private string[] _dialogues;
    private TextMeshProUGUI _text;

    private int _dialogueIndex;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>(true);
    }

    public void ChoiceFishing()
    {
        if (_dialogueIndex == 0)
        {
            _dialogueIndex = 0;
            _text.text = _dialogues[_dialogueIndex];
            _interactions.SetActive(true);
            _choices.SetActive(true);
        }
        else if (_dialogueIndex > 0) 
        {
            StartCoroutine(SlimonDialogues());
        }
    }

    public void AcceptFishing()
    {
        _choices.SetActive(false);       
        _dialogueIndex++;
        _text.text = _dialogues[_dialogueIndex];
        _dialogueIndex++;
    }

    public void RefuseFishing()
    {
        _interactions.SetActive(false);
        _choices.SetActive(false);
    }

    private IEnumerator SlimonDialogues()
    {
        if (_dialogueIndex < _dialogues.Length)
        {
            _text.text = _dialogues[_dialogueIndex];
            _dialogueIndex++;
        }
        else
        {
            _blackscreen.SetActive(true);
            yield return new WaitForSecondsRealtime(0.5f);
            gameObject.SetActive(false);
            _blackscreen.SetActive(false);
            _map3.SetActive(false);
            _map3Bis.SetActive(true);
        }
    }
}
