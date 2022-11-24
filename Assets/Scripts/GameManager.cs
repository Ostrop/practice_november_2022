
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject loseWindow;
    public static GameManager instance;
    public TextMeshProUGUI score, highScore, tokensText;
    [SerializeField] private int scoreCounter, highScoreCounter, tokens;
    public Player player;

    void Awake()
    {
        instance = this;

        if (PlayerPrefs.HasKey("SaveScore"))
            highScoreCounter = PlayerPrefs.GetInt("SaveScore");
        else
            highScoreCounter = 0;
        if (PlayerPrefs.HasKey("Tokens"))
            tokens = PlayerPrefs.GetInt("Tokens");
        else
            tokens = 0;

        scoreCounter = 0;
        highScore.text = "Лучший результат: " + highScoreCounter;
        tokensText.text = "Душ: " + tokens;
        
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        Time.timeScale = 1;
    }

    void Update()
    {

        score.text = "Результат: " + scoreCounter;
        tokensText.text = "Душ: " + tokens;
        
        if (Input.GetKeyDown(KeyCode.Escape))
            MenuScene();
    }


    public void RestartScene()
    {
        SceneManager.LoadScene("MainGame");
        Time.timeScale = 1;
        scoreCounter = 0;
    }


    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Lose()
    {
        loseWindow.SetActive(true);
        Time.timeScale = 0;
    }

    public void AddScore()
    {
        scoreCounter++;

        HighScore();
    }
    public void UseUlty()
    {
        tokens-= 3;
        PlayerPrefs.SetInt("Tokens", tokens);
    }

    public void AddToken()
    {
        tokens++;

        PlayerPrefs.SetInt("Tokens", tokens);
    }

    public void HighScore()
    {
        if (scoreCounter > highScoreCounter)
        {
            highScoreCounter = scoreCounter;
        }
        highScore.text = "Лучший результат: " + highScoreCounter;

        PlayerPrefs.SetInt("SaveScore", highScoreCounter);
    }

    public void ResetScore()
    {
        scoreCounter = 0;
    }
}