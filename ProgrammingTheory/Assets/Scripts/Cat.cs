using UnityEngine;

public class Cat : Animal
{
    protected override string Name
    {
        get => base.Name;
        set
        {
            if (string.IsNullOrEmpty(value) && value.Length < 10)
            {
                Name = value;
                return;
            }

            Debug.LogError("Name is too long for cat!");
        }
    }

    private void Update()
    {
        Move();
        Jump();
    }

    protected override void Jump()
    {
        if (!IsGrounded()) return;

        rb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
    }

    protected override void Move()
    {
        rb.AddForce(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    protected override void Talk()
    {
        Debug.Log("Meow");
    }

    private void OnMouseDown()
    {
        Talk();
    }
}
