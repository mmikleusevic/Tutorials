using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private static string PLAYER = "Player";

    [SerializeField] private float speed = 30f;

    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.FindWithTag(PLAYER).GetComponent<PlayerController>();    
    }

    private void Update()
    {
        if (playerController.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
