using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject sphere;
    [SerializeField] private int numberToSpawn;
    [SerializeField] private float yLowerBound;
    [SerializeField] private float yUpperBound;
    [SerializeField] private float zLowerBound;
    [SerializeField] private float zUpperBound;

    private void Start()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            Vector3 position = new Vector3(0, Random.Range(yLowerBound, yUpperBound), Random.Range(zLowerBound, zUpperBound));
            Instantiate(sphere, position, Quaternion.identity);
        }
    }
}
