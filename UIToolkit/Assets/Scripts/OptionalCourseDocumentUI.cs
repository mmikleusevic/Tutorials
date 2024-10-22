using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OptionalCourseDocumentUI : MonoBehaviour
{
    [SerializeField] private List<Fraction> fractions;
    VisualElement root;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        InitializeBadges();

        new DropdownController(root, fractions);
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
