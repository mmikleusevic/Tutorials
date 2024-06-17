using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 250;

    private Rigidbody enemyRb;
    private GameObject player;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * Time.deltaTime * speed);

        if (transform.position.z > 10)
        {
            Destroy(gameObject);
        }
    }
}
