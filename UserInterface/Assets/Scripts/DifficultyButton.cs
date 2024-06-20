using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button difficultyButton;
    private GameManager gameManager;

    public int difficulty;

    private void Awake()
    {
        difficultyButton = GetComponent<Button>();
        difficultyButton.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
