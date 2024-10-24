using Assets.Scripts;
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
}