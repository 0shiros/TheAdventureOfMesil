using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlimonFishing : MonoBehaviour
{
    [SerializeField] private Image _slimonFish;
    [SerializeField] private TextMeshProUGUI _slimonFishText;
    [SerializeField] private Image _blackScreen;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _playerFishing;

    public void ChoiceFishing()
    {
        _slimonFish.gameObject.SetActive(true);
    }

    public void WantToFish()
    {
        _slimonFish.gameObject.SetActive(false);
        AttackVillage();
    }

    public void DoesntWantToFish()
    {
        _slimonFish.gameObject.SetActive(false);
    }

    private IEnumerator AttackVillage()
    {
        _blackScreen.gameObject.SetActive(true);
        _player.SetActive(false);
        _playerFishing.SetActive(true);
        yield return new WaitForSeconds(2f);
        _slimonFish.gameObject.SetActive(true);


    }
}
