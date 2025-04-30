using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float rotSpeed = 15.0f;
    [SerializeField] private float moveSpeed = 6.0f;
    [SerializeField] private float jumpSpeed = 15.0f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float terminalVelocity = -10.0f;
    [SerializeField] private float minFall = -1.5f;

    private CharacterController charController;
    private ControllerColliderHit contact;
    private Animator animator;
    private float vertSpeed;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        vertSpeed = minFall;
    }

    private void Update()
    {
        Vector3 movement = Vector3.zero;

        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");

        if (horInput != 0 || verInput != 0)
        {
            Vector3 right = target.right;
            Vector3 forward = Vector3.Cross(right, Vector3.up);

            movement = (right * horInput) + (forward * verInput);
            movement *= moveSpeed;
            movement = Vector3.ClampMagnitude(movement, moveSpeed);


            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);
        }
        
        bool hitGround = false;
        RaycastHit hit;
        if (vertSpeed < 0 &&
            Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float check = (charController.height + charController.radius) / 1.9f;
            hitGround = hit.distance <= check;
        }
        
        animator.SetFloat("Speed", movement.sqrMagnitude);
        
        if (hitGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                vertSpeed = jumpSpeed;
            }
            else
            {
                vertSpeed = minFall;
                animator.SetBool("Jumping", false);
            }
        }
        else
        {
            vertSpeed += gravity * 5 * Time.deltaTime;
            if (vertSpeed < terminalVelocity)
            {
                vertSpeed = terminalVelocity;
            }

            if (contact != null)
            {
                animator.SetBool("Jumping", true);
            }

            if (charController.isGrounded)
            {
                if (Vector3.Dot(movement, contact.normal) < 0)
                {
                    movement = contact.normal * moveSpeed;
                }
                else
                {
                    movement += contact.normal * moveSpeed;
                }
            }
        }

        movement.y = vertSpeed;
        movement *= Time.deltaTime;

        charController.Move(movement);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        contact = hit;
    }
}