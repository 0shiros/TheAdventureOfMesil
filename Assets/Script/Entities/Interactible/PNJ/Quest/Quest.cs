using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    private string _questState;
    private Image _sign;
    [SerializeField] private Sprite[] _signs;
    [HideInInspector] public string _interactionMessage;
    [SerializeField] private string[] _dialogues;

    // GenericPropertyJSON:{"name":"_dialogues","type":-1,"arraySize":3,"arrayType":"string","children":[{"name":"Array","type":-1,"arraySize":3,"arrayType":"string","children":[{"name":"size","type":12,"val":3},{"name":"data","type":3,"val":"Vas me slimer des baies dans la slor\u00eat au slud-est, je te serai slredevable "},{"name":"data","type":3,"val":"Les baies que je slerche sont dans la slor\u00eat au slud-est  "},{"name":"data","type":3,"val":"Slimerci, \u00e7a va m'aider \u00e0 slimager sa douleir"}]}]}

    private void Awake()
    {
        _sign = GetComponentInChildren<Image>();
    }

    public void CurrentCompletionQuest()
    {
        switch (_questState)
        {
            case "Available":
                Available();
                break;
            case "InProgress":
                InProgress();
                break;
            case "Complete":
                Complete();
                break;
        }

    }

    private void Available()
    {
        _questState = "InProgress";
        _sign.sprite = _signs[0];
        _interactionMessage = _dialogues[0];
    }

    private void InProgress()
    {
        _interactionMessage = _dialogues[1];
    }

    private void Complete()
    {
        _interactionMessage = _dialogues[2];
    }
}

