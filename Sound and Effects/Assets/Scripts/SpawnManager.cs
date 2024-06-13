using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static string PLAYER = "Player";

    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float startDelay = 2f;
    [SerializeField] private float repeatRate = 2f;

    private PlayerController playerController;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    void Start()
    {
        playerController = GameObject.FindWithTag(PLAYER).GetComponent<PlayerController>();
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
    }

    private void SpawnObstacle() 
    {
        if (playerController.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
