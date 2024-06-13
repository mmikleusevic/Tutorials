using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private static string PLAYER = "Player";
    private static string OBSTACLE = "Obstacle";

    [SerializeField] private float speed = 30f;
    [SerializeField] private float leftBound = -15f;

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

        if (transform.position.x < leftBound && gameObject.CompareTag(OBSTACLE))
        {
            Destroy(gameObject);
        }
    }
}
