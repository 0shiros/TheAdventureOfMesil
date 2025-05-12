using TMPro;
using UnityEngine;

public class BossKilled : MonoBehaviour
{
    [Header("References")]
    [TextArea(3, 10)]
    [SerializeField] private string _textStory; 
    private TextMeshProUGUI _textPanelStory;
    [SerializeField] private GameObject _panelStory;

    [SerializeField] private GameObject _player;
    private PlayerPotion _playerPotion;

    private void Awake()
    {
        _playerPotion = _player.GetComponent<PlayerPotion>();
        _textPanelStory = _panelStory.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnDisable()
    {
        BossDeath();
    }

    private void BossDeath()
    {
        _playerPotion.AddPotion();
        PlayerRespawn.instance.Respawn();
        _textPanelStory.text = _textStory;
        _panelStory.SetActive(true);
    }
}
