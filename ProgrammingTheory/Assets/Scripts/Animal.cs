using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float jumpForce = 10f;

    protected Rigidbody rb;
    protected float distanceToGround = 1f;

    protected virtual string Name { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected abstract void Move();
    protected abstract void Jump();
    protected abstract void Talk();

    protected virtual bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * distanceToGround, Color.red, 10f);
        return Physics.Raycast(transform.position, Vector3.down, distanceToGround);
    }
}
