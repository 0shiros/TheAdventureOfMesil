using UnityEngine;

public class DestroyStone : MonoBehaviour
{
    [SerializeField] private SecondBossKilled _secondBossKilled;
    [SerializeField] private GameObject _interactions;
    [SerializeField] private GameObject _choices;
    private GameObject _stone;

    private void Awake()
    {
        _stone = gameObject;
    }

    private void Update()
    {
        if (_secondBossKilled._hasSecondBossBeenKilled)
        {
            StoneChoice();
        }
    }

    private void StoneChoice()
    {
        _stone.tag = "Untagged";
        _interactions.SetActive(true);
        _choices.SetActive(true);
    }

    public void AcceptStoneChoice()
    {
        SFXManager.instance.PlaySFX("RockExplosion");
        _stone.SetActive(false);
        _interactions.SetActive(false);
        _choices.SetActive(false);
    }

    public void RefuseStoneChoice()
    {
        _interactions.SetActive(false);
        _choices.SetActive(false);
    }
}
