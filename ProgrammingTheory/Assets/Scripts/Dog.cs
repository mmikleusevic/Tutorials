using UnityEngine;

public class Dog : Animal
{
    protected override string Name
    {
        get => base.Name;
        set
        {
            if (string.IsNullOrEmpty(value) && value.Length < 5)
            {
                Name = value;
                return;
            }

            Debug.LogError("Name is too long for dog!");
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
        Debug.Log("Woof");
    }

    private void OnMouseDown()
    {
        Talk();
    }
}
