using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        nameInputText.onSelect.AddListener((string value) => SetBestScore(value));
        nameInputText.onValueChanged.AddListener((string value) => SetBestScore(value));
    }

    private void Start()
    {
        nameInputText.text = MenuManager.Instance.highScorePlayerName;

        if (MenuManager.Instance.highScore > 0)
        {
            SetBestScore(MenuManager.Instance.highScorePlayerName);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SetBestScore(string name)
    {
        MenuManager.Instance.newPlayerName = name;

        scoreText.text = MenuManager.Instance.GetBestScore();
    }
}
