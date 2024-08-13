using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public Text pointsText;
    public SnakeController SnakeController;
    public GameObject targetGameObject;

    public string tagName = "musicBackGround";

    public void VictorySetup(int score)
    {
        DestroyObjectWithTag(tagName);
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "/25";
        Time.timeScale = 0;
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene("MenuPrincipal");
        Time.timeScale = 1;
    }

    public void DestroyObjectWithTag(string tagName)
    {
        GameObject targetObject = GameObject.FindWithTag(tagName);
        if (targetObject != null)
        {
            Destroy(targetObject);
        }
    }

}
