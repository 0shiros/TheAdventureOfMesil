using UnityEngine;

public class BossDeath : MonoBehaviour
{
    [SerializeField] private GameEvents _gameEvents;
    [SerializeField] private PlayerPotion _playerPotion;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GameObject _goodEnd;
    [SerializeField] private GameObject _bossCorruptedTreant;

    private void Update()
    {
        if (!_bossCorruptedTreant.activeSelf)
        {
            BossKilled();
        }
    }

    private void BossKilled()
    {
        _gameEvents.hasPlayerKilledFirstBoss = true;
        _playerPotion.AddPotion();
        _goodEnd.SetActive(true);
    }

}
