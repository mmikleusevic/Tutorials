using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Game game;
    [SerializeField] private UI ui;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        game.InitializeGame();
        UpdateUI();
    }

    public void HandleWrongAnswer()
    {
        game.HandleWrongAnswer();
        UpdateUI();
    }

    public void HandleCorrectAnswer()
    {
        game.HandleCorrectAnswer();
        UpdateUI();
    }

    public void CheckAnswer(string answer)
    {
        bool answerCorrect = game.IsAnswerCorrect(answer);

        if (answerCorrect)
        {
            HandleCorrectAnswer();
            Debug.Log("Answer was correct!");
        }
        else
        {
            HandleWrongAnswer();
            Debug.Log("Answer was wrong!");
        }

        ui.GiveAnswerFeedback(answerCorrect);
    }

    public void UpdateUI()
    {
        ui.SetHint(game.GetCurrentHint());
        ui.SetHintNumber(game.GetCurrentHintNumber());
        ui.SetQuestionNumber(game.GetCurrentQuestionNumber());
    }

    public List<Question> GetAllQuestions()
    {
        return game.questions;
    }
}