using UnityEngine.UIElements;

internal class TooltipController
{
    public TooltipController(VisualElement root)
    {
        VisualElement tooltipElement1 = root.Q("tooltip1");
        VisualElement tooltipElement2 = root.Q("tooltip2");
        VisualElement tooltipElement3 = root.Q("tooltip3");

        Tooltip reusableTooltip = new Tooltip();
        root.Add(reusableTooltip);

        tooltipElement1.AddManipulator(new TooltipManipulator(reusableTooltip));
        tooltipElement2.AddManipulator(new TooltipManipulator(reusableTooltip));
        tooltipElement3.AddManipulator(new TooltipManipulator(reusableTooltip));
    }
}