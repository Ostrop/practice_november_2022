using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultWindow : MonoBehaviour
{
    public TextMeshProUGUI highScore;

    void Awake()
    {
        if (PlayerPrefs.HasKey("SaveScore"))
            highScore.text = "Лучший результат: " + PlayerPrefs.GetInt("SaveScore");
        else
            highScore.text = "Лучший результат: " + 0;
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
