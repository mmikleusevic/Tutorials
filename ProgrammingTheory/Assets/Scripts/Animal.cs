using UnityEngine;

// INHERITANCE
public abstract class Animal : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float jumpForce = 10f;

    protected Rigidbody rb;
    protected float distanceToGround = 1f;

    // ENCAPSULATION
    protected virtual string Name { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // POLYMORPHYSM
    protected abstract void Move();
    // POLYMORPHYSM
    protected abstract void Jump();
    // POLYMORPHYSM
    protected abstract void Talk();

    // ABSTRACTION
    protected virtual bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * distanceToGround, Color.red, 10f);
        return Physics.Raycast(transform.position, Vector3.down, distanceToGround);
    }
}
