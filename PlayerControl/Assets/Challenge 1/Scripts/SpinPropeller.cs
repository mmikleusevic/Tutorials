using UnityEngine;

public class SpinPropeller : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }
}
