using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI highestScorerName, highestScore;
    [SerializeField] private Button startButton, exitButton; // For Unity Event matching

    private void Start() => SetBestPlayerNameAndScore();

    public void LoadMainSceneButton()
    {
        SaveManager.Instance.SaveCurrentPlayerName(inputField.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        FindObjectOfType<SaveManager>().Load();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

    private void SetBestPlayerNameAndScore()
    {
        highestScorerName.text = $"Player Name: {SaveManager.Instance.GetBestPlayerName()}";
        highestScore.text = $"Best Player Score: {SaveManager.Instance.GetBestPlayerScore()}";
    }
}