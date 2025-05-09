using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompleteQuest : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Quest _quest;
    private GameObject _questObject;

    [Header("Dialogue")]
    public string _objectDialogue;

    public Action OnQuestUpdated { get; internal set; }

    private void Awake()
    {
        _questObject = gameObject;
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
