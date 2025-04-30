using System;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    public float rotSpeed = 1.5f;

    private float rotY;
    private Vector3 offset;

    private void Start()
    {
        rotY = transform.rotation.eulerAngles.y;
        offset = target.position - transform.position;
    }

    private void LateUpdate()
    {
        float horInput = Input.GetAxis("Horizontal");
        if (!Mathf.Approximately(horInput, 0))
        {
            rotY += horInput * rotSpeed;
        }
        else
        {
            rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;
        }

        Quaternion rotation = Quaternion.Euler(0, rotY, 0);
        transform.position = target.position - (rotation * offset);
        transform.LookAt(target);
    }
}
