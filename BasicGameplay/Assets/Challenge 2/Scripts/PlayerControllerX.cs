using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    [SerializeField] private float defaultTimer = 2f;

    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && timer < 0)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            timer = defaultTimer;
        }
    }
}
