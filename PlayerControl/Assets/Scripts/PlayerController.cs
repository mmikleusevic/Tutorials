using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        // Move the vehicle forward

        transform.Translate(Vector3.forward * Time.deltaTime * 20);
    }
}
