using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private const string HIGHSCORE = "Highscore";
    private const string NAME = "Name";
    private const string CURRENT_PLAYER_NAME = "CurrentName";
    public static SaveManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Save(int score)
    {
        if (PlayerPrefs.GetInt(HIGHSCORE) <= score)
        {
            PlayerPrefs.SetInt(HIGHSCORE, score);
            PlayerPrefs.SetString(NAME, PlayerPrefs.GetString(CURRENT_PLAYER_NAME));
        }
    }

    public void Load()
    {
        PlayerPrefs.GetInt(HIGHSCORE, 0);
        PlayerPrefs.GetString(NAME, " ");
    }

    public string GetBestPlayerName() => PlayerPrefs.GetString(NAME, string.Empty);

    public int GetBestPlayerScore() => PlayerPrefs.GetInt(HIGHSCORE);

    public void SaveCurrentPlayerName(string currentPlayerName) => PlayerPrefs.SetString(CURRENT_PLAYER_NAME, currentPlayerName);
}