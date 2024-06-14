using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float delay = 2f;
    [SerializeField] private float repeatTime = 8f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), delay, repeatTime);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, new Vector3(0, 0, 6), enemyPrefab.transform.rotation);
    }
}
