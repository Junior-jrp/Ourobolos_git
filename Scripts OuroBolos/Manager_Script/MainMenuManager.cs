using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private GameObject painelMainMenu;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private AudioSource musicalBackground;

    public void Jogar()
    {
        SceneManager.LoadScene(levelName);
        Time.timeScale = 1;
    }


    public void AbrirOpcoes()
    {
        painelMainMenu.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelMainMenu.SetActive(true);
        painelOpcoes.SetActive(false);
    }


    public void SairDoJogo()
    {
        Application.Quit();
    }

    public void MusicalVolume(float value)
    {
        musicalBackground.volume = value;
    }

}
