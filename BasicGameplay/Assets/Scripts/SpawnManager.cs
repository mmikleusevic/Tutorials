using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs;
    private int animalIndex = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject animalPrefab = animalPrefabs[animalIndex];

            Instantiate(animalPrefab, new Vector3(0, 0, 20), animalPrefab.transform.rotation);
        }
    }
}
