using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManeger : MonoBehaviour
{
    public static GameUIManeger instance;

    public Text scoreText;
    public Text timer;
    public bool timeIsRunning = true;
    public string difficulty = "";
    [SerializeField]
    public int score = 0;
    public float timeRemaining = 0;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        string difficulty = PlayerPrefs.GetString("SelectedDifficulty", "medio");
        DifficultyTimer(difficulty);
        scoreText.text = score.ToString() + "/25";
        GameOverScreen.gameObject.SetActive(false);
        timeIsRunning = true;
    }

    private void Update()
    {

        if (timeIsRunning)
        {
            if (timeRemaining > 0 && score != 25)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }

            else if (timeRemaining <= 0 && score != 25)
            {
                GameOver();
            }

            else if (score >= 25)
            {

                GameWin();

            }
        }
    }

    public void ScoreUpdate()
    {
        score += 1;
        scoreText.text = score.ToString() + "/25";

    }

    public GameOverScreen GameOverScreen;
    public void GameOver()
    {
        GameOverScreen.Setup(score);
    }

    public VictoryScreen VictoryScreen;
    public void GameWin()
    {
        VictoryScreen.VictorySetup(score);
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timer.text = string.Format("{0:00}:{1:00}", minutes , seconds);
    }

    public void DifficultyTimer(string difficulty)
    {
        if (difficulty == "facil")
        {
            timeRemaining = 300;
        }
        if (difficulty == "medio")
        {
            timeRemaining = 150;
        }
        if (difficulty == "dificil")
        {
            timeRemaining = 90;
        }
    }

}
