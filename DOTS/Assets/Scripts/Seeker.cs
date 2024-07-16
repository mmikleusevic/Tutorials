using UnityEngine;

public class Seeker : MonoBehaviour
{
    public Vector3 direction;

    private void Update()
    {
        transform.localPosition += direction * Time.deltaTime;
    }
}
