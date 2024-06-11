using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 cameraOffset;

    private void LateUpdate()
    {
        transform.position = player.transform.position + cameraOffset;
    }
}
