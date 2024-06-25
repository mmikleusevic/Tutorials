using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private readonly float speed = 20f;
    [SerializeField] private float horsePower = 20f;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private InputAction playerMovement;

    private Rigidbody rb;
    private float horizontalInput;
    private Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        moveDirection = playerMovement.ReadValue<Vector2>();

        // Moves the car forward based on vertical input
        rb.AddRelativeForce(Vector3.forward * Time.deltaTime * horsePower * moveDirection.y);
        // Rotates the car based on horizontal input
        transform.Rotate(GetTurningFactor());
    }

    private void OnEnable()
    {
        playerMovement.Enable();
    }

    private void OnDisable()
    {
        playerMovement.Disable();
    }

    public Vector3 GetTurningFactor()
    {
        return Vector3.up * turnSpeed * Time.deltaTime * moveDirection.x;
    }
}
