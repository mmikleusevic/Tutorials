using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.forward * speed * forwardInput * Time.deltaTime);
    }
}
