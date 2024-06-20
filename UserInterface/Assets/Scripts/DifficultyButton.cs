using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button difficultyButton;

    private void Awake()
    {
        difficultyButton = GetComponent<Button>();
        difficultyButton.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        Debug.Log(difficultyButton.gameObject.name + " was clicked");
    }
}
