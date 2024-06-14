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
        enemyRb.AddForce((player.transform.position - transform.position).normalized * Time.deltaTime * speed);
    }
}
