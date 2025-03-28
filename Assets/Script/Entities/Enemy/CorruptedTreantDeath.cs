using UnityEngine;

public class CorruptedTreantDeath : MonoBehaviour
{
    [SerializeField] private GameEvents _gameEvents;
    [SerializeField] private PlayerPotion _playerPotion;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GameObject _goodEnd;

    private void BossKilled()
    {
        _gameEvents.hasPlayerKilledFirstBoss = true;
        _playerPotion.AddPotion();
        _goodEnd.SetActive(true);
    }

}
