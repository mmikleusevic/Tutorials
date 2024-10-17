using UnityEngine;
using UnityEngine.UIElements;

public class ButtonScreen : MonoBehaviour
{
    private Button button;
    private VisualElement box;

    private void OnEnable()
    {
        VisualElement rootElement = GetComponent<UIDocument>().rootVisualElement;
        button = rootElement.Q<Button>("button");
        box = rootElement.Q<VisualElement>("box");

        button.clicked += OnClick;
    }

    private void OnDisable()
    {
        button.clicked -= OnClick;
    }

    private void OnClick()
    {
        int randomWidth = Random.Range(50, 300);
        int randomHeight = Random.Range(50, 300);

        box.style.width = randomWidth;
        box.style.height = randomHeight;
    }
}
