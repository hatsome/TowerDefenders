using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void OnRetryClick()
    {
        SceneManager.LoadScene("TowerDefenseScene");
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }

    public void OnMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }

}
