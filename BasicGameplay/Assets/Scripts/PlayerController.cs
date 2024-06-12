using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float xRange = 10f;

    private float horizontalInput;

    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
    }
}
