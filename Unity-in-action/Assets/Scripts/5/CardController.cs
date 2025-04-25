using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class CardController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreLabel;
    
    [SerializeField] private const int gridRows = 2;
    [SerializeField] private const int gridCols = 4;
    [SerializeField] private const float offsetX = 2f;
    [SerializeField] private const float offsetY = 2.5f;
    
    [SerializeField] private MemoryCard originalCard;
    [SerializeField] private Sprite[] images;

    private MemoryCard firstRevealed;
    private MemoryCard secondRevealed;
    private int score = 0;
    
    public bool canReveal => !secondRevealed;

    private void Start()
    {
        Vector3 startPos = originalCard.transform.position;

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShuffleArray(numbers);

        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard);
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                card.SetCard(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];

        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        
        return newArray;
    }
    
    public void CardRevealed(MemoryCard card)
    {
        if (firstRevealed == null)
        {
            firstRevealed = card;
        }
        else
        {
            secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }
    
    private IEnumerator CheckMatch()
    {
        if (firstRevealed.Id == secondRevealed.Id)
        {
            score++;
            scoreLabel.text = $"Score: {score}";
        }
        else
        {
            yield return new WaitForSeconds(.5f);
            
            firstRevealed.Unreveal();
            secondRevealed.Unreveal();
        }

        firstRevealed = null;
        secondRevealed = null;
    }

    private void Restart()
    {
        SceneManager.LoadScene("5");
    }
}
