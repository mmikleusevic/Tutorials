using UnityEngine.UIElements;

public class TooltipManipulator : PointerManipulator
{
    private Tooltip tooltip;

    public TooltipManipulator(Tooltip tooltip)
    {
        this.tooltip = tooltip;
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<PointerEnterEvent>(OnPointerEnter);
        target.RegisterCallback<PointerLeaveEvent>(OnPointerLeave);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<PointerEnterEvent>(OnPointerEnter);
        target.UnregisterCallback<PointerLeaveEvent>(OnPointerLeave);
    }

    private void OnPointerLeave(PointerLeaveEvent evt)
    {
        tooltip.Show(target, evt.localPosition);
    }

    private void OnPointerEnter(PointerEnterEvent evt)
    {
        tooltip.Hide();
    }
}