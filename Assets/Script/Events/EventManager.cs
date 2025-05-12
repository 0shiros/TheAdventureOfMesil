using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Animator[] _doorGridAnimators;
    [SerializeField] private FirstBossKilled _firstBossKilled;
    [SerializeField] private GameObject _druidess;
    [SerializeField] private GameObject _duidessStopPlayer;

    private void Update()
    {
        if(_player.activeSelf == false && _firstBossKilled._hasTreantBeenKilled == false)
        {
            ResetGrids();
        }

        UnlockDesertArea();
    }

    public void ResetGrids()
    {
        for (int i = 0; i < _doorGridAnimators.Length; i++)
        {
            Collider2D _doorGrid = _doorGridAnimators[i].GetComponent<Collider2D>();
            _doorGridAnimators[i].SetBool("IsPlayerEnter", false);
            _doorGrid.isTrigger = true;
        }
    }

    private void UnlockDesertArea()
    {
        if (_firstBossKilled._hasTreantBeenKilled)
        {
            _firstBossKilled._hasTreantBeenKilled = false;
            _druidess.SetActive(false);
            _duidessStopPlayer.SetActive(false);
        }
    }
}
