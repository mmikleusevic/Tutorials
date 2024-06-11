using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float turnSpeed = 10f;
    
    private float horizontalInput;
    private float verticalInput;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
