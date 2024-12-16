using UnityEngine;

public class ParallaxCam : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private void Update()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f) * (speed * Time.deltaTime);
    }
}
