using UnityEngine;

public class Target : MonoBehaviour
{
    public Vector3 direction;

    private void Update()
    {
        transform.localPosition += direction * Time.deltaTime;
    }
}
