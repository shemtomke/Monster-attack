using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Modes currentMode;

    public bool isGameOver = false;
    public bool isStartGame = false;

    public int gamesPlayed = 0;
    public Text gamesPlayedText;

    string saveGamesPlayed = "GAMESPLAYED";

    private void Update()
    {
        UpdateGamesPlayed();
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
}
public enum Modes
{
    Normal, Hard
}