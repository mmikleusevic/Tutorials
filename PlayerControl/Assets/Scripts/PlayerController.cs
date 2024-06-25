using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower = 20f;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private InputAction playerMovement;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] private List<WheelCollider> wheelColliders;

    private Rigidbody rb;
    private float horizontalInput;
    private Vector2 moveDirection;
    private float speed;
    private float rpm;
    private int wheelsOnGround;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.transform.position;
    }

    private void FixedUpdate()
    {
 

        moveDirection = playerMovement.ReadValue<Vector2>();

        // Moves the car forward based on vertical input
        rb.AddRelativeForce(Vector3.forward * Time.deltaTime * horsePower * moveDirection.y);

        if (IsOnGround())
        {
            speed = Mathf.RoundToInt(rb.velocity.magnitude * 3.6f);
            speedometerText.text = "Speed: " + speed + "km/h";

            rpm = speed % 30 * 40;
            rpmText.text = "PRM: " + rpm;
        }

        // Rotates the car based on horizontal input
        transform.Rotate(GetTurningFactor());
    }

    private bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider collider in wheelColliders)
        {
            if (collider.isGrounded) wheelsOnGround++;
        }

        if (wheelsOnGround == 4) return true;

        return false;
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
