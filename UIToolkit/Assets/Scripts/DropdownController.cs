using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    public class DropdownController
    {
        private VisualElement root;

        private Fraction currentFraction = null;

        public DropdownController(VisualElement root, List<Fraction> fractions)
        {
            this.root = root;

            VisualElement conainer = root.Q("dropdownContainer");

            PopupField<Fraction> dropdown = new PopupField<Fraction>();

            dropdown.choices = fractions;
            dropdown.value = fractions[0];
            currentFraction = fractions[0];

            dropdown.formatListItemCallback = (elem) => elem.fractionName;
            dropdown.formatSelectedValueCallback = (elem) => elem.fractionName;

            dropdown.RegisterCallback<ChangeEvent<Fraction>>(OnFractionSelected);

            conainer.Add(dropdown);

            UpdateUI();
        }

        private void OnFractionSelected(ChangeEvent<Fraction> evt)
        {
            currentFraction = evt.newValue;
            UpdateUI();
        }

        private void UpdateUI()
        {
            VisualElement characterElem = root.Q<VisualElement>("character");
            Sprite charImg = Resources.Load<Sprite>(currentFraction.characterImgPath);
            characterElem.style.backgroundImage = new StyleBackground(charImg);

            Label fractionLabel = root.Q<Label>("fractionName");
            fractionLabel.text = currentFraction.fractionName;

            Label mottoLabel = root.Q<Label>("fractionMotto");
            mottoLabel.text = currentFraction.fractionMotto;

            VisualElement fractionImgElem = root.Q<VisualElement>("panelFraction");
            Sprite fractionImg = Resources.Load<Sprite>(currentFraction.fractionImgPath);
            fractionImgElem.style.backgroundImage = new StyleBackground(fractionImg);
        }
    }
}