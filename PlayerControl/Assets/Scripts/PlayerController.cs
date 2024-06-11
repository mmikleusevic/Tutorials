using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float turnSpeed = 2f;

    private void Update()
    {
        // Move the vehicle forward

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed);
    }
}
