using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isStartGame = false;

    [Header("Game Over")]
    public GameObject gameOverUI;
    public bool isGameOver = false;

    [Header("Sound Settings")]
    public AudioSource bgMusic;
    bool isMute = false; // sound - on
    bool isVibration = false; // vibration - off

    [Header("Game Stats")]
    public Modes currentMode;
    public int gamesPlayed = 0;
    public Text gamesPlayedText;
    string saveGamesPlayed = "GAMESPLAYED";
    private void Update()
    {
        UpdateGamesPlayed();
        GameOver();

        // Sound and Vibration
        bgMusic.mute = isMute ? true : false;
        if(isVibration) { Handheld.Vibrate(); }
    }

    #region Number of Games Played
    public void SaveGamesPlayed(int numberOfGames)
    {
        PlayerPrefs.SetInt(saveGamesPlayed, numberOfGames);
    }
    public int GetNumberOfGames()
    {
        return PlayerPrefs.GetInt(saveGamesPlayed);
    }
    void UpdateGamesPlayed()
    {
        gamesPlayed = GetNumberOfGames();
        gamesPlayedText.text = "" + GetNumberOfGames();
    }
    #endregion

    public void Retry()
    {
        // Reload the current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isGameOver = false;
    }
    // Sound
    public void Sound()
    {
        isMute = !isMute;
    }
    public void Vibration()
    {
        isVibration = !isVibration;
    }
    public void ResetGameOver()
    {
        isGameOver = false;
    }
    void GameOver()
    {
        if (isGameOver)
            gameOverUI.SetActive(true);
    }
    public void SelectDiffuclty(string mode)
    {
        // check if mode is in the modes enum
        Modes selectedMode;

        if (Enum.TryParse(mode, out selectedMode))
        {
            // The string matched one of the enum values.
            currentMode = selectedMode;
        }
    }
}
public enum Modes
{
    Normal, Hard
}