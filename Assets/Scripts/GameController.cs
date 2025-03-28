using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private float gameDuration = 60f;
    private TextMeshProUGUI gameOverText;
    private float timeRemaining;
    private bool isGameOver = false;

    private void Start()
    {
        timeRemaining = gameDuration;
        gameOverPanel.SetActive(false);
                
        gameOverText = gameOverPanel.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeDisplay();
            if (timeRemaining <= 0)
            {
                EndGame();
            }
        }
    }

    private void UpdateTimeDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timeText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }

    private void EndGame()
    {
        isGameOver = true;
        timeText.text = "00:00";
        Time.timeScale = 0f;

        gameOverPanel.SetActive(true);

        if (SlimeCounter.Instance != null)
        {
            gameOverText.text = $"Game over\n\nYour score: {SlimeCounter.Instance.SlimeCount}";
        }
        else
        {
            gameOverText.text = "Game over";
        }
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
