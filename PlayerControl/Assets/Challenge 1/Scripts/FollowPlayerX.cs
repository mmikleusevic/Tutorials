using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    [SerializeField] private GameObject plane;
    [SerializeField] private Vector3 offset;

    private void LateUpdate()
    {
        transform.position = plane.transform.position + offset;
    }
}
