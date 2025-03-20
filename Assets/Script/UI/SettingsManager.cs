using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    [SerializeField] private Toggle _fullscreenToggle;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume") || PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }

        if (PlayerPrefs.HasKey("fullScreen"))
        {
            LoadToggleScreen();
        }
        else
        {
            SetToggleScreen();
        }

        SetFullScreen();
    }

    public void SetMusicVolume()
    {
        float volume = _musicSlider.value;
        _audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SetSFXVolume()
    {
        float volume = _sfxSlider.value;
        _audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        _sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMusicVolume();
        SetSFXVolume();
    }

    public void SetToggleScreen()
    {
        int toggle = _fullscreenToggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt("fullScreen", toggle);
    }

    private void LoadToggleScreen()
    {
        _fullscreenToggle.isOn = (PlayerPrefs.GetInt("fullScreen") != 0);

        SetToggleScreen();
    }

    public void SetFullScreen()
    {
        Screen.fullScreen = _fullscreenToggle.isOn;
    }
}
