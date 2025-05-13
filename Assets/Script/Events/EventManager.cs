using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Animator[] _doorGridFirstDonjonAnimators;
    [SerializeField] private Animator[] _doorGridLastDonjonAnimators;
    [SerializeField] private FirstBossKilled _firstBossKilled;
    [SerializeField] private GameObject _druidess;
    [SerializeField] private GameObject _duidessStopPlayer;

    private void Update()
    {
        if (_player.activeSelf == false)
        {
            ResetGrids(_doorGridLastDonjonAnimators);

            if (_firstBossKilled._hasTreantBeenKilled == false)
            {
                ResetGrids(_doorGridFirstDonjonAnimators);
            }
        }

        UnlockDesertArea();
    }

    public void ResetGrids(Animator[] grids)
    {
        for (int i = 0; i < grids.Length; i++)
        {
            Collider2D _doorGrid = grids[i].GetComponent<Collider2D>();
            grids[i].SetBool("IsPlayerEnter", false);
            _doorGrid.isTrigger = true;
        }
    }

    private void UnlockDesertArea()
    {
        if (_firstBossKilled._hasTreantBeenKilled)
        {
            _druidess.SetActive(false);
            _duidessStopPlayer.SetActive(false);
        }
    }
}
