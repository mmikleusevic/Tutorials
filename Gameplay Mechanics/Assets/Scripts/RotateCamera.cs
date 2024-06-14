using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float speed = 50f;

    private float horizontalInput;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, speed * Time.deltaTime * horizontalInput);
    }
}
