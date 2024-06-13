using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static string GROUND = "Ground";
    private static string OBSTACLE = "Obstacle";

    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;

    private Rigidbody playerRb;
    private bool isOnGround = true;
    private bool gameOver = false;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GROUND))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag(OBSTACLE))
        {
            Debug.Log("Game Over");
            gameOver = true;
        }
    }
}
