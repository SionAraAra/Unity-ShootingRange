using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    public void AddScore(int amount)
    {
        score += amount;

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}