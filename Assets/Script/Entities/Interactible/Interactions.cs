using TMPro;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    public string[] _interactionMessage;

    [SerializeField] private bool _randomizeMessage = false;

    private int _index = 0;

    public string CurrentMessage()
    {
        if (_interactionMessage.Length > 0 && _randomizeMessage == true)
        {
            return _interactionMessage[Random.Range(0, _interactionMessage.Length)];
        }
        else if (_interactionMessage.Length > 0 && _randomizeMessage == false)
        {
           return Dialogues();
        }
        else
        {
            return "No interaction message available.";
        }
    }

    private string Dialogues()
    {   
        while (_index < _interactionMessage.Length)
        {
            string message = _interactionMessage[_index];
            _index++;

            if (_index >= _interactionMessage.Length)
            {
                _index = 0;
            }

            return message;            
        }

        return "No more messages available.";
    }
}
