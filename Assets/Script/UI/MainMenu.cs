using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void Fullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }   
}
