using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    [SerializeField] private List<QuestState> _questState = new();
    private Image _sign;

    private void Awake()
    {
        _sign = GetComponentInChildren<Image>();
    }

    public void CurrentCompletionQuest()
    {
        
    }

    private void TakeQuest()
    {
        
    }

    private void QuestUncomplete()
    {
       
    }

    private void QuestComplete()
    {
      
    }
}

[System.Serializable]
public struct QuestState
{
    public string state;
    public Sprite visualFeedback;
}
