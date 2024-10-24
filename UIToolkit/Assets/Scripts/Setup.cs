using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    public class Setup
    {
        public static void Initialize(VisualElement root)
        {
            InitializeDragDrop(root);
            InitializeIcons(root);
        }

        private static void InitializeDragDrop(VisualElement root)
        {
            root.Query<VisualElement>("iconBoard")
                .Children<VisualElement>().ForEach(child =>
                {
                    child.AddManipulator(new IconDragger(root));
                });
        }

        private static void InitializeIcons(VisualElement root)
        {

        }
    }
}