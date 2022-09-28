using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highestScorerName, highestScore;
    [SerializeField] private Button startButton, exitButton; // For Unity Event matching

    private NewPlayer player;

    public void StartGame()
    {
        LoadMainScene();
        //SaveManager.Instance.LoadData();
        //NewSavingSystem.LoadPlayerName(player);
        CheckForNameAndScore();
    }

    private static void CheckForNameAndScore()
    {
        PlayerPrefs.GetString("Name", " ");
        PlayerPrefs.GetInt("HighScore", 0);
    }

    private void LoadMainScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    public void ExitGame()
    {
        NewSavingSystem.SavePlayerName(player);
        NewSavingSystem.SavePlayerScore(player);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
