using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * 100, ForceMode.Impulse);
        }
    }
}
