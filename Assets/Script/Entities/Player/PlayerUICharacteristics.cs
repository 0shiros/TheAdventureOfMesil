using TMPro;
using UnityEngine;

public class PlayerUICharacteristics : MonoBehaviour
{
    [SerializeField] private GameObject _characteristicsUI;
    [SerializeField] private TextMeshProUGUI _levelTxt;
    [SerializeField] private TextMeshProUGUI _experienceTxt;
    [SerializeField] private TextMeshProUGUI _healthTxt;
    [SerializeField] private TextMeshProUGUI _staminaTxt;
    [SerializeField] private TextMeshProUGUI _damageTxt;

    private void Awake()
    {
        UpdateStatisticsUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !_characteristicsUI.activeSelf)
        {
            _characteristicsUI.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.C) && _characteristicsUI.activeSelf) 
        {
            _characteristicsUI.SetActive(false);
        }
    }

    public void UpdateStatisticsUI()
    {
        PlayerCharacteristics _playerCharacteristics = _playerCharacteristics = GetComponent<PlayerCharacteristics>();

        _levelTxt.text = $"Niveau : {_playerCharacteristics.level.ToString()}";

        _experienceTxt.text = $"Expérience : {_playerCharacteristics.currentExperience.ToString()}/{_playerCharacteristics.maxExperiences[_playerCharacteristics.level].ToString()}";

        _healthTxt.text = $"Point de vie : {_playerCharacteristics.currentHealth.ToString()}/{_playerCharacteristics.maxHealth.ToString()}";

        _staminaTxt.text = $"Endurance : {_playerCharacteristics.currentStamina.ToString()}/{_playerCharacteristics.maxStamina.ToString()}";

        _damageTxt.text = $"Dégâts : {_playerCharacteristics.damage.ToString()}";
    }
}
