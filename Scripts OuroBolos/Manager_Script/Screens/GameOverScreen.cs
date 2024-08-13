using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public SnakeController SnakeController;
    public void Setup(int score) 
   {
     gameObject.SetActive(true);
     pointsText.text = score.ToString() + "/25";
        Time.timeScale = 0;
    }

public void PlayAgainButton() {

        Time.timeScale = 1;
        SceneManager.LoadScene("Level 01");
        
    }

public void MenuButton()
{

        SceneManager.LoadScene("MenuPrincipal");
        Time.timeScale = 1;
    }

public void RestartGame() {

        SceneManager.LoadScene("Level 01");
        Time.timeScale = 1;
    }
}
