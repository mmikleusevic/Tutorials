using UnityEngine;
using UnityEngine.UIElements;

public class IconDragger : MouseManipulator
{
    private VisualElement dragArea;
    private VisualElement iconContainer;
    private VisualElement dropZone;

    private Vector2 startPos;
    private Vector2 elememStartPosGlobal;
    private Vector2 elememEndPosLocal;

    private bool isActive;

    public IconDragger(VisualElement root)
    {
        dragArea = root.Q<VisualElement>("dragArea");
        dropZone = root.Q<VisualElement>("dropZone");

        isActive = false;
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<MouseDownEvent>(OnMouseDown);
        target.RegisterCallback<MouseMoveEvent>(OnMouseMove);
        target.RegisterCallback<MouseUpEvent>(OnMouseUp);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<MouseDownEvent>(OnMouseDown);
        target.UnregisterCallback<MouseMoveEvent>(OnMouseMove);
        target.UnregisterCallback<MouseUpEvent>(OnMouseUp);
    }

    private void OnMouseDown(MouseDownEvent evt)
    {
        iconContainer = target.parent;

        startPos = evt.localMousePosition;

        elememStartPosGlobal = target.worldBound.position;
        elememEndPosLocal = target.layout.position;

        dragArea.style.display = DisplayStyle.Flex;
        dragArea.Add(target);

        target.style.top = elememStartPosGlobal.y;
        target.style.left = elememStartPosGlobal.x;

        isActive = true;
        target.CaptureMouse();
        evt.StopPropagation();
    }

    private void OnMouseMove(MouseMoveEvent evt)
    {
        if (!isActive || !target.HasMouseCapture()) return;

        Vector2 diff = evt.localMousePosition - startPos;

        target.style.top = target.layout.y + diff.y;
        target.style.left = target.layout.x + diff.x;

        evt.StopPropagation();
    }

    private void OnMouseUp(MouseUpEvent evt)
    {
        if (!isActive || !target.HasMouseCapture()) return;

        iconContainer.Add(target);

        target.style.left = elememEndPosLocal.x - iconContainer.contentRect.position.x;
        target.style.top = elememEndPosLocal.y - iconContainer.contentRect.position.y;

        isActive = false;
        target.ReleaseMouse();
        evt.StopPropagation();

        dragArea.style.display = DisplayStyle.None;
    }
}