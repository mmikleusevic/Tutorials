using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;

    private void Update()
    {
        transform.Rotate(0, speed, 0, Space.World);
    }
}
