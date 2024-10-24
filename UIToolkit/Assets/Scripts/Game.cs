using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public List<Question> questions = new List<Question>();
    private Question currentQuestion;

    private int questionIndex = 0;
    private string currentHint;
    private int hintIndex = 0;

    public void InitializeGame()
    {
        currentQuestion = questions[questionIndex];
        currentHint = currentQuestion.GetHints()[hintIndex];
    }

    public bool IsAnswerCorrect(string answer)
    {
        return currentQuestion.answer == answer;
    }

    public void HandleCorrectAnswer()
    {
        NextQuestion();
    }

    public void HandleWrongAnswer()
    {
        if (hintIndex < 2)
        {
            currentHint = currentQuestion.GetHints()[++hintIndex];
        }
        else
        {
            NextQuestion();
        }
    }

    private void NextQuestion()
    {
        currentQuestion = questions[++questionIndex];

        hintIndex = 0;
        currentHint = currentQuestion.GetHints()[hintIndex];
    }

    public Question GetCurrentQuestion()
    {
        return currentQuestion;
    }

    public int GetCurrentQuestionNumber()
    {
        return questionIndex + 1;
    }

    public string GetCurrentHint()
    {
        return currentHint;
    }

    public int GetCurrentHintNumber()
    {
        return hintIndex + 1;
    }
}