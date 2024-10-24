using System.Collections.Generic;
using UnityEngine.UIElements;

public class EpochCarousel : VisualElement
{
    public new class UxmlFactory : UxmlFactory<EpochCarousel> { }

    public string[] textEntries =
    {
        "Neolithic",
        "Ancient",
        "Classical",
        "Medieval",
        "Early Modern",
        "Industrial",
        "Contemporary"
    };

    private const string styleResource = "EpochCarouselStyle";
    private const string ussCarouselContainer = "carouselContainer";
    private const string ussElement = "elemet";
    private const string ussBulletContainer = "bulletContainer";
    private const string ussMainContainer = "mainContainer";
    private const string ussScrollView = "scrollView";
    private const string ussButton = "button";
    private const string ussButtonRight = "buttonRight";
    private const string ussScrollContainer = "scrollContainer";
    private const string ussScrollText = "scrollText";
    private const string ussEpochLabel = "epochLabel";
    private const string ussOuterBullet = "outerBullet";
    private const string ussInnerBullet = "innerBullet";

    private ScrollView scrollView;
    private Label priorEpochLabel;
    private Label nextEpochLabel;

    private VisualElement bulletContainer;

    private int currentContentIndex = 0;
    private List<VisualElement> currentContent = new List<VisualElement>();
    private List<VisualElement> activeBullets = new List<VisualElement>();

    private int CurrentContentIndex
    {
        get => currentContentIndex;

        set
        {
            if (value >= 0 && value < currentContent.Count)
            {
                currentContentIndex = value;
            }
        }
    }

    public EpochCarousel()
    {
        VisualElement carouselContainer = new VisualElement();
        carouselContainer.AddToClassList(ussCarouselContainer);
        hierarchy.Add(carouselContainer);

        VisualElement element = new VisualElement();
        element.AddToClassList(ussElement);
        bulletContainer = new VisualElement();
        bulletContainer.AddToClassList(ussBulletContainer);
        hierarchy.Add(element);
        element.Add(bulletContainer);

        scrollView = new ScrollView(ScrollViewMode.Horizontal);
        scrollView.AddToClassList(ussScrollView);
        scrollView.contentContainer.parent.AddToClassList(ussScrollContainer);
        scrollView.horizontalScrollerVisibility = ScrollerVisibility.Hidden;

        Button leftButton = new Button();
        Button rightButton = new Button();
        leftButton.AddToClassList(ussButton);
        rightButton.AddToClassList(ussButton);
        rightButton.AddToClassList(ussButtonRight);

        leftButton.clicked += () => OnLeftClicked();
        rightButton.clicked += () => OnRightClicked();

        priorEpochLabel = new Label();
        nextEpochLabel = new Label();
        priorEpochLabel.AddToClassList(ussEpochLabel);
        nextEpochLabel.AddToClassList(ussEpochLabel);

        carouselContainer.Add(priorEpochLabel);
        carouselContainer.Add(leftButton);
        carouselContainer.Add(scrollView);
        carouselContainer.Add(rightButton);
        carouselContainer.Add(nextEpochLabel);

        InitializeContent();
        UpdateTextLabel();
        UpdateBullets();
        currentContent = (List<VisualElement>)scrollView.Children();

        CurrentContentIndex = 0;
    }

    private void OnLeftClicked()
    {
        CurrentContentIndex--;
        scrollView.ScrollTo(currentContent[CurrentContentIndex]);
        UpdateTextLabel();
        UpdateBullets();
    }

    private void OnRightClicked()
    {
        CurrentContentIndex++;
        scrollView.ScrollTo(currentContent[CurrentContentIndex]);
        UpdateTextLabel();
        UpdateBullets();
    }

    private void InitializeContent()
    {
        foreach (var item in textEntries)
        {
            Label newLabel = new Label(item);
            newLabel.AddToClassList(ussScrollText);
            scrollView.Add(newLabel);

            VisualElement newBullet = new VisualElement();
            newBullet.AddToClassList(ussOuterBullet);
            bulletContainer.Add(newBullet);

            VisualElement newInnerBullet = new VisualElement();
            newInnerBullet.AddToClassList(ussInnerBullet);
            newBullet.Add(newInnerBullet);

            activeBullets.Add(newInnerBullet);
        }
    }

    private void UpdateBullets()
    {
        activeBullets.ForEach((elem) => elem.style.visibility = Visibility.Hidden);
        activeBullets[currentContentIndex].style.visibility = Visibility.Visible;
    }

    private void UpdateTextLabel()
    {
        if (currentContentIndex > 0)
        {
            priorEpochLabel.text = textEntries[currentContentIndex - 1];
        }
        else
        {
            priorEpochLabel.text = string.Empty;
        }

        if (currentContentIndex < textEntries.Length - 1)
        {
            nextEpochLabel.text = textEntries[currentContentIndex + 1];
        }
        else
        {
            nextEpochLabel.text = string.Empty;
        }
    }
}