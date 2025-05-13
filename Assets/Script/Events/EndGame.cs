using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject endGamePanel;

    private void OnDisable()
    {
        EndPanel();
    }

    private void EndPanel()
    {
        endGamePanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
