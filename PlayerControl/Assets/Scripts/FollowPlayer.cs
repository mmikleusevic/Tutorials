using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private Vector3[] cameraOffsets;
    [SerializeField] private PlayerController playerController;
    private int offsetIndex = 0;

    private void Start()
    {
        cameraOffset = cameraOffsets[offsetIndex];
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + GetNewCameraOffset();
        transform.Rotate(playerController.GetTurningFactor());
    }

    private Vector3 GetNewCameraOffset()
    {
        if (!Input.GetKeyUp(KeyCode.Space)) return cameraOffset;

        offsetIndex++;

        if (offsetIndex >= cameraOffsets.Length)
        {
            offsetIndex = 0;
        }

        cameraOffset = cameraOffsets[offsetIndex];
        return cameraOffsets[offsetIndex];
    }
}
