using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompleteQuest : MonoBehaviour
{
    [SerializeField] private Quest _quest;
    public string _objectDialogue;
    private GameObject _questObject;

    public Action OnQuestUpdated { get; internal set; }

    private void Awake()
    {
        _questObject = GetComponent<CompleteQuest>().gameObject;
    }

    public void UpdateQuest()
    {
        _quest._currentDialogue = _quest._dialogues[2];
        _quest._signImage.sprite = _quest._signSprites[2];
        _quest._isQuestCompleted = true;
        _questObject.tag = "Untagged";
        OnQuestUpdated?.Invoke();
    }
}
