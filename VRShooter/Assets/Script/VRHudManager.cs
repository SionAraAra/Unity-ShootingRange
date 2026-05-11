using UnityEngine;
using TMPro;

public class VRHudManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI endedScoreText;
    public GameObject gameOverPanel;
    public GameObject mainUI;
    public float timeLeft = 120f;

    private int score = 0;
    private bool timerRunning = true;

    void Start()
    {
        UpdateScoreText();
        UpdateTimerText();
    }

    void Update()
    {
        if (!timerRunning)
        {
            return;
        }

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            timerRunning = false;

            mainUI.SetActive(false);
            gameOverPanel.SetActive(true);
            endedScoreText.text = "End Score: " + score;
        }

        UpdateTimerText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        timerText.text = "Time: " + minutes + ":" + seconds.ToString("00");
    }
}