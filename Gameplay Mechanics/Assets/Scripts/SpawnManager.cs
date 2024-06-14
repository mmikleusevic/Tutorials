using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float delay = 2f;
    [SerializeField] private float repeatTime = 8f;
    [SerializeField] private float spawnRange = 9f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), delay, repeatTime);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnPositionX, 0, spawnPositionZ);
    }
}
