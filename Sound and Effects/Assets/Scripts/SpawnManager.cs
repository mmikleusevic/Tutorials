using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float startDelay = 2f;
    [SerializeField] private float repeatRate = 2f;

    private Vector3 spawnPos = new Vector3(25, 0, 0);

    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
    }

    private void SpawnObstacle() 
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
