using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private bool paused = false;
    private GameObject gameMenu;


    private void Start()
    {
        gameMenu = GameObject.Find("GameMenu");
        gameMenu.SetActive(false);
    }

    public void OpenGameMenu()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
            gameMenu.SetActive(true);
        }
    }

    public void ContinueGame()
    {
        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
            gameMenu.SetActive(false);
        }
    }

    public void OpenMainMenu()
    {
        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
            gameMenu.SetActive(false);
            SceneManager.LoadScene("Scenes/Menu");
        }
        else
        {
            SceneManager.LoadScene("Scenes/Menu");
        }
    }

    public void StartGame()
    {
        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
            gameMenu.SetActive(false);
            SceneManager.LoadScene("Scenes/Level1");
        }
        else
        {
            SceneManager.LoadScene("Scenes/Level1");
        }
    }

}