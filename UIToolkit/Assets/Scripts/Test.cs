using UnityEngine;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        VisualElement icon = root.Q("testIcon");

        icon.AddManipulator(new IconDragger(root, null));
    }
}