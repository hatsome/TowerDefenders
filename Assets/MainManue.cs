using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManue : MonoBehaviour
{
    public void Start_Game()
    {
        SceneManager.LoadScene("TowerDefenseScene");
    }

    public void Quit_Game()
    {
        Application.Quit();
    }
}
