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
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPosition = new Vector3(spawnPositionX, 0, spawnPositionZ);

        Instantiate(enemyPrefab, randomPosition, enemyPrefab.transform.rotation);
    }
}
