using System;
using UnityEngine;
using UnityEngine.Serialization;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0, 
        MouseX = 1, 
        MouseY = 2
    }
    
    [SerializeField] private RotationAxes axes = RotationAxes.MouseXAndY;
    
    [SerializeField] private float sensitivityHor = 9.0f;
    [FormerlySerializedAs("sensitivityVer")] [SerializeField] private float sensitivityVert = 9.0f;
    
    [SerializeField] private float minVert = -45.0f;
    [SerializeField] private float maxVert = 45.0f;

    [SerializeField] private float verticalRot = 0;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.freezeRotation = true;
        }
    }

    private void Update()
    {
        if (axes == RotationAxes.MouseX) {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY) {
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
            verticalRot = Mathf.Clamp(verticalRot, minVert, maxVert);
            
            float horizontalRot = transform.localEulerAngles.y;
            
            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
        else {
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
            verticalRot = Mathf.Clamp(verticalRot, minVert, maxVert);
            
            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float horizontalRot = transform.localEulerAngles.y + delta;
            
            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
    }
}
