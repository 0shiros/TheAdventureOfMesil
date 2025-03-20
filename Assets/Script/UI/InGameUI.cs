using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    private void Awake()
    {
        SetGamePause(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            PauseMenu();
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void SetGamePause(bool isPaused)
    {
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void PauseMenu()
    {
        if(_pauseMenu.activeSelf)
        {
            _pauseMenu.SetActive(false);
            SetGamePause(false);
        }
        else
        {
            _pauseMenu.SetActive(true);
            SetGamePause(true);
        }
    }
}
