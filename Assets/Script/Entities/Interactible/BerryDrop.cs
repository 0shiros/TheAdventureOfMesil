using System.Collections.Generic;
using UnityEngine;

public class BerryDrop : MonoBehaviour
{
    [Header("References")]
    private CompleteQuest _completeQuest;

    [Header("Settings")]
    private List<GameObject> _berries;

    private void Awake()
    {
        _berries = new List<GameObject>();
        foreach (Transform child in transform)
        {
            _berries.Add(child.gameObject);
        }

        _completeQuest = GetComponent<CompleteQuest>();
        _completeQuest.OnQuestUpdated += HandleQuestUpdated;
    }

    private void HandleQuestUpdated()
    {
        foreach (var berry in _berries)
        {
            if (berry != null)
            {
                berry.SetActive(false);
            }
        }

        _completeQuest.OnQuestUpdated -= HandleQuestUpdated;
    }
}
