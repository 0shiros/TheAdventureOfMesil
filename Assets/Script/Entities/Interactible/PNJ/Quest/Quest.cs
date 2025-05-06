using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public string[] _dialogues;
    public Sprite[] _signSprites;
    [SerializeField] private int _experienceReward;

    [SerializeField] private PlayerCharacteristics _playerCharacteristics;
    private GameObject _questObject;
    [HideInInspector] public Image _signImage;
    [HideInInspector] public string _currentDialogue;

    public bool _isQuestStarted = false;
    public bool _isQuestCompleted = false;

    //GenericPropertyJSON:{"name":"_dialogues","type":-1,"arraySize":3,"arrayType":"string","children":[{"name":"Array","type":-1,"arraySize":3,"arrayType":"string","children":[{"name":"size","type":12,"val":3},{"name":"data","type":3,"val":"Vas me slimer des baies dans la sloret au slud-est, je te serai slredevable"},{"name":"data","type":3,"val":"Les baies que je slerche sont dans la sloret au slud-est "},{"name":"data","type":3,"val":"Slimerci, \u00e7a va m'aider \u00e0 slimager sa douleur"}]}]}

    private void Awake()
    {
        _questObject = GetComponent<Quest>().gameObject;
        _signImage = GetComponentInChildren<Image>();
    }

    public void CurrentQuestState()
    {
        switch (true) 
        {
            case var _ when !_isQuestStarted: 
                StartQuest();
                break;
            case var _ when _isQuestStarted && !_isQuestCompleted:
                InProgressQuest();
                break;
            case var _ when _isQuestCompleted:
                CompleteQuest();
                break;
        }
    }

    private void StartQuest()
    {
        _signImage.sprite = _signSprites[1];
        _currentDialogue = _dialogues[0];
        _isQuestStarted = true;
    }

    private void InProgressQuest()
    {
        _currentDialogue = _dialogues[1];
    }

    private void CompleteQuest()
    {
        _signImage.gameObject.SetActive(false);
        _questObject.tag = "Untagged";
        _playerCharacteristics.GainExperience(_experienceReward);
    }
}

