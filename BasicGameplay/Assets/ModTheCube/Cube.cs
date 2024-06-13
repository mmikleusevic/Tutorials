using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    [SerializeField] private float speed = 30f;

    private float timer = 5f;
    private float defaultTimer;
    
    void Start()
    {
        transform.position = new Vector3(Random.Range(0, 4), Random.Range(0, 4), Random.Range(0, 4));
        transform.localScale = Vector3.one * Random.Range(1f, 3f);
        
        Material material = Renderer.material;
        
        material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 0.0f);

        defaultTimer = timer;
    }
    
    void Update()
    {
        Material material = Renderer.material;

        Color color = material.color;

        timer -= Time.deltaTime;

        if (timer > 0)
        {
            color.a += 0.0008f;
        }
        else
        {
            color.a -= 0.0008f;

            if (timer < -defaultTimer)
            {
                timer = defaultTimer;
            }
        }

        material.color = color;

        transform.Rotate(10.0f * Time.deltaTime * speed, 10.0f * Time.deltaTime * speed, 10.0f  * Time.deltaTime * speed);
    }
}
