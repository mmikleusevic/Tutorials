using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 20f;

    void Update()
    {
        // Move the vehicle forward

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
