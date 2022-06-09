using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int score = 0;
    public TMP_Text text;

    private void Awake()
    {
        Time.timeScale = 0;
        if(instance == null)
        {
            instance = this;
        }
    }
    public void UpdateText()
    {
        text.text = "Score: " + score;
    }
    public void AddScore()
    {
        score++;
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
