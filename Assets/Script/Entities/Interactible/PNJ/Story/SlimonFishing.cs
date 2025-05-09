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
        _dialogueIndex++;
        _text.text = _dialogues[_dialogueIndex];
        _choices.SetActive(false);       
    }

    public void RefuseFishing()
    {
        _interactions.SetActive(false);
        _choices.SetActive(false);
    }

    private IEnumerator SlimonDialogues()
    {
        while (_dialogueIndex < _dialogues.Length)
        {
            _text.text = _dialogues[_dialogueIndex++];
            _dialogueIndex++;
            
            yield return null;
        }

        _blackscreen.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        _blackscreen.SetActive(false);
        gameObject.SetActive(false);
        _map3.SetActive(false);
        _map3Bis.SetActive(true);        
    }
}
