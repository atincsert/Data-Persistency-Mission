using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveWithPlayerPrefs : MonoBehaviour
{
    public int Score, currentHighScore;
    public string Name;

    public void SaveNewHighScore()
    {
        if (Score <= currentHighScore) return;
        if (Score > currentHighScore)
        {
            currentHighScore = Score;
            PlayerPrefs.SetInt("CurrentHighScore", currentHighScore);
            PlayerPrefs.SetString("NameOfTheNewHighScorer", Name);
        }
        
    }

}
