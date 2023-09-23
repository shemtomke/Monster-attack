using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    private int highScore;
    private string saveScoreKey = "HighScore"; // PlayerPrefs key for high score

    public Text bestScoreText;

    private void Start()
    {
        LoadHighScore();
    }
    private void Update()
    {
        // Update and display the current score
        scoreText.text = "" + score;

        // Check if the current score is higher than the high score
        if (score > highScore)
        {
            // If yes, update the high score
            highScore = score;
            // Save the new high score
            SaveHighScore();
        }

        // Display the high score
        bestScoreText.text = "" + highScore;
    }
    // Save the high score to PlayerPrefs
    private void SaveHighScore()
    {
        PlayerPrefs.SetInt(saveScoreKey, highScore);
    }

    // Load the high score from PlayerPrefs
    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt(saveScoreKey, 0); // Default to 0 if no high score is saved
    }
}
