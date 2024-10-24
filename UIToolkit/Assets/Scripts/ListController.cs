using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    public class ListController
    {
        private VisualElement root;
        private ListView list;
        private List<ListItem> listItems;

        private ListItem chosenItem;

        public ListController(VisualElement root, List<ListItem> listItems)
        {
            this.root = root;
            this.listItems = listItems;

            CreateList();
        }

        private void CreateList()
        {
            list = root.Q<ListView>("list");
            VisualTreeAsset listItemAsset = Resources.Load<VisualTreeAsset>("listItem");

            list.makeItem = () => listItemAsset.Instantiate();
            list.bindItem = (visualElement, index) =>
            {
                VisualElement fractionIcon = visualElement.Q<VisualElement>("fractionIcon");
                Label name = visualElement.Q<Label>("listItemName");
                Label score = visualElement.Q<Label>("score");
                VisualElement uselessIcon = visualElement.Q<VisualElement>("otherIcon");
                Label reward = visualElement.Q<Label>("reward");

                ListItem currentItem = listItems[index];

                Sprite iconImg = Resources.Load<Sprite>(currentItem.itemIconPath);
                fractionIcon.style.backgroundImage = new StyleBackground(iconImg);

                name.text = currentItem.itemName;
                score.text = currentItem.score;

                Sprite uselessIconImg = Resources.Load<Sprite>(currentItem.itemIconPath2);
                uselessIcon.style.backgroundImage = new StyleBackground(uselessIconImg);

                reward.text = currentItem.reward;
            };

            list.itemsSource = listItems;
            list.fixedItemHeight = 40;
            list.selectionChanged += (elem) => OnSelectionChanged(elem);
        }

        private void OnSelectionChanged(IEnumerable<object> elem)
        {
            chosenItem = elem.First() as ListItem;
            UpdateDetails();
        }

        private void UpdateDetails()
        {
            VisualElement detailImg = root.Q<VisualElement>("detailing");
            Sprite iconImg = Resources.Load<Sprite>(chosenItem.itemIconPath);
            detailImg.style.backgroundImage = new StyleBackground(iconImg);

            Label fractionLabel = root.Q<Label>("detailName");
            fractionLabel.text = chosenItem.itemName;

            Label fractionScore = root.Q<Label>("detailsScore");
            fractionScore.text = "Score: " + chosenItem.score;

            VisualElement scoreImg = root.Q<VisualElement>("detailsScoreImg");
            Sprite scoreSprite = Resources.Load<Sprite>(chosenItem.itemIconPath2);
            scoreImg.style.backgroundImage = new StyleBackground(scoreSprite);

            Label rewardLabel = root.Q<Label>("detailsReward");
            rewardLabel.text = "Reward: " + chosenItem.reward;
        }
    }
}