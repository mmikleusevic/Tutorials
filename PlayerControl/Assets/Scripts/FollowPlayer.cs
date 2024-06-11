using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 5, -7);
    }
}
