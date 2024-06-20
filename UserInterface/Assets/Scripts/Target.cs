using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    private void Awake()
    {
        targetRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        targetRb.AddForce(Vector3.up * Random.Range(12, 16), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);

        transform.position = new Vector3(Random.Range(-4, 4), -6);
    }
}