using Assets.Scripts;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    [SerializeField] private Controller controller;

    private VisualElement root;
    private Label hint;
    private Label hintNumberLabel;
    private Label questionNumberLabel;
    private Label timeLabel;
    private Label answerIndicator;
    private Label highscoreLabel;
    private Label currentScoreLabel;
    private Button nextHintButton;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        hint = root.Q<Label>("hint");
        hintNumberLabel = root.Q<Label>("hintNum");
        questionNumberLabel = root.Q<Label>("questionCounter");
        nextHintButton = root.Q<Button>("nextHintButton");
        timeLabel = root.Q<Label>("counterLabel");
        answerIndicator = root.Q<Label>("answerIndicator");
        highscoreLabel = root.Q<Label>("highscore");
        currentScoreLabel = root.Q<Label>("myScore");

        Initialize();
    }

    public void Initialize()
    {
        nextHintButton.clicked += () => controller.HandleWrongAnswer();

        Setup.InitializeDragDrop(root, controller);
        Setup.InitializeIcons(root, controller.GetAllQuestions());
    }

    public void GiveAnswerFeedback(bool correct)
    {
        answerIndicator.style.visibility = Visibility.Visible;
        StyleColor collorCorrect = new StyleColor(new Color32(0, 132, 19, 255));
        StyleColor collorWrong = new StyleColor(new Color32(132, 0, 19, 255));

        if (correct)
        {
            answerIndicator.text = "Your answer was correct";
            answerIndicator.style.color = collorCorrect;
        }
        else
        {
            answerIndicator.text = "Your answer was wrong";
            answerIndicator.style.color = collorWrong;
        }

        StartCoroutine(CleanUpQuestion());
    }

    public void SetHint(string hint)
    {
        this.hint.text = hint;
    }

    public void SetHintNumber(int hintNumber)
    {
        hintNumberLabel.text = "Hint " + hintNumber + ":";
    }

    public void SetQuestionNumber(int questionNumber)
    {
        questionNumberLabel.text = "Question " + questionNumber;
    }

    private IEnumerator CleanUpQuestion()
    {
        yield return new WaitForSeconds(2f);
        answerIndicator.style.visibility = Visibility.Hidden;

        VisualElement dropZone = root.Q<VisualElement>("dropBox");

        if (dropZone.childCount > 0)
        {
            dropZone.RemoveAt(0);
        }
    }
}