using UnityEngine;
using UnityEngine.UIElements;

public class ColorPanel : VisualElement
{
    public new class UxmlFactory : UxmlFactory<ColorPanel> { }
    public ColorPanel()
    {
        VisualElement panel = new VisualElement();

        panel.style.width = 200;
        panel.style.height = 200;
        panel.style.backgroundColor = Color.cyan;

        hierarchy.Add(panel);
    }
}