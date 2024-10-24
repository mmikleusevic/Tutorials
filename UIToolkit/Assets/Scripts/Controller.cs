using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Game game;
    [SerializeField] private UI ui;

    private int currentCounter;
    public int CurrentCounter
    {
        get => currentCounter;

        set
        {
            if (value == 0)
            {
                HandleWrongAnswer();
                return;
            }

            ui.SetTimer(value);
            currentCounter = value;
        }
    }

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        game.InitializeGame();
        UpdateUI();

        ResetCounter();
        StartCoroutine(UpdateCounter());
    }

    public void HandleWrongAnswer()
    {
        game.HandleWrongAnswer();
        UpdateUI();
        ResetCounter();
    }

    public void HandleCorrectAnswer()
    {
        game.HandleCorrectAnswer();
        UpdateUI();
        ResetCounter();
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

    private void ResetCounter()
    {
        CurrentCounter = 30;
    }

    public IEnumerator UpdateCounter()
    {
        yield return new WaitForSeconds(1);

        CurrentCounter--;

        StartCoroutine(UpdateCounter());
    }
}