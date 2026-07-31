using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public int winScore = 10;
    public bool gameEnded = false;

    public GameObject gameOverUI;
    public GameObject winUI;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    void Start()
    {
        UpdateScore();
    }

    public void AddScore()
    {
        if (gameEnded) return;

        score++;
        Debug.Log("Score: " + score);
        UpdateScore();

        if (score >= winScore)
        {
            WinGame();
        }
    }

    void UpdateScore()
    {
        if (scoreText != null)
            scoreText.text = score + "/" + winScore;
    }

    public void GameOver()
    {
        if (gameEnded) return;

        gameEnded = true;
        Debug.Log("GAME OVER");

        if (gameOverUI != null)
            gameOverUI.SetActive(true);

        Time.timeScale = 0f;
    }

    void WinGame()
    {
        gameEnded = true;
        Debug.Log("YOU WON");

        if (winUI != null)
            winUI.SetActive(true);

        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}