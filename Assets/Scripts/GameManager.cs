using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public bool isStartGame = false;

    public int gamesPlayed = 0;
    public Text gamesPlayedText;

    string saveGamesPlayed = "GAMESPLAYED";

    private void Awake()
    {
        
    }

    #region Number of Games Played
    public void SaveGamesPlayed(int numberOfGames)
    {
        PlayerPrefs.SetInt(saveGamesPlayed, numberOfGames);
    }
    public int GetNumberOfGames()
    {
        return PlayerPrefs.GetInt(saveGamesPlayed, gamesPlayed);
    }
    void UpdateGamesPlayed()
    {
        gamesPlayedText.text = "" + gamesPlayed;
    }
    #endregion


}
