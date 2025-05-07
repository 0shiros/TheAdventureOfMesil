using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerCharacteristics _playerCharacteristics;
    private GameObject _questObject;
    [HideInInspector] public Image _signImage;

    [Header("QuestSettings")]
    public string[] _dialogues;
    [HideInInspector] public string _currentDialogue;    
    public Sprite[] _signSprites;
    public bool _isQuestStarted = false;
    public bool _isQuestCompleted = false;

    [Header("QuestReward")]
    [SerializeField] private int _experienceReward;

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

