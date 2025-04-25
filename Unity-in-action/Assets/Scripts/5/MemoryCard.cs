using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private CardController cardController;
    [SerializeField] private GameObject cardBack;
    
    public int Id { get; private set; }

    private void OnMouseDown()
    {
        if (cardBack.activeSelf && cardController.canReveal)
        {
            cardBack.SetActive(false);
            cardController.CardRevealed(this);
        }
    }

    public void Unreveal()
    {
        cardBack.SetActive(true);
    }
    
    public void SetCard(int id, Sprite image)
    {
        Id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
}
