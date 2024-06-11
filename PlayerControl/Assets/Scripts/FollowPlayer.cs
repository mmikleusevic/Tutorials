using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 cameraOffset;

    private void Update()
    {
        transform.position = player.transform.position + cameraOffset;
    }
}
