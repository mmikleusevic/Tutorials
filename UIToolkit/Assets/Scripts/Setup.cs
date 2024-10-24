using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    public class Setup
    {
        public static void InitializeDragDrop(VisualElement root)
        {
            root.Query<VisualElement>("iconBoard")
                .Children<VisualElement>().ForEach(child =>
                {
                    child.AddManipulator(new IconDragger(root));
                });
        }

        public static void InitializeIcons(VisualElement root, List<Question> questions)
        {
            int currentIconIndex = 0;

            foreach (Question question in questions)
            {
                VisualElement questionIcon = root.Query<VisualElement>("iconBoard").Children<VisualElement>().AtIndex(currentIconIndex);
                questionIcon.style.backgroundImage = Resources.Load<Texture2D>("Images/" + question.answer);
                questionIcon.userData = question;

                currentIconIndex++;
            }
        }
    }
}