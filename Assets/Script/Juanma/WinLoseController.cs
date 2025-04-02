using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseController : MonoBehaviour
{
    public GameObject WinPanel, LosePanel;
    void Start()
    {
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
    }

    public void Win()
    {
        WinPanel.SetActive(true);
        LosePanel.SetActive(false);
    }

    public void Lose()
    {
        WinPanel.SetActive(false);
        LosePanel.SetActive(true);
    }

    public void Restart()
    {
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu() {
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    
}
