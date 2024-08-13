using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public SnakeController SnakeController;
    public GameUIManeger GameUIManeger;
    public ControlsScreen ControlsScreen;
    public void Pause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;

    }

    public void RestartButton()
    {

        SceneManager.LoadScene("Level 01");
        Time.timeScale = 1;

    }

    public void MenuButton()
    {

        SceneManager.LoadScene("MenuPrincipal");
        Time.timeScale = 1;

    }

    public void CloseButton()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;

    }

    public void ControlScreen()
    {
        ControlsScreen.ControlsMenu();
    }

}
