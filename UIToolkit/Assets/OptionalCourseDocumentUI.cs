using UnityEngine;
using UnityEngine.UIElements;

public class OptionalCourseDocumentUI : MonoBehaviour
{
    VisualElement root;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        InitializeBadges();
    }

    private void InitializeBadges()
    {
        string[] romanNumbers = { "I", "II", "III", "IV", "V", "VI" };

        int index = 0;

        root.Query("panelBadges")
            .Descendents<VisualElement>()
            .Name("labelLevel").ForEach(elem => (elem as Label).text = romanNumbers[index++]);
    }
}
