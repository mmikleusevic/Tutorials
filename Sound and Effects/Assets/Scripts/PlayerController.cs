using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static string GROUND = "Ground";
    private static string OBSTACLE = "Obstacle";

    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;

    private Rigidbody playerRb;
    private Animator playerAnimator;

    private bool isOnGround = true;
    public bool gameOver = false;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            dirtParticle.Stop();
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GROUND))
        {
            dirtParticle.Play();
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag(OBSTACLE))
        {
            dirtParticle.Stop();
            explosionParticle.Play();
            gameOver = true;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
        }
    }
}
