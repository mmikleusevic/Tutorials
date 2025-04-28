using System;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 4.5f;
    [SerializeField] private float jumpForce = 12.0f;
    
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D box;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        
        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        }
        
        Vector2 movement = new Vector2(deltaX, rb.linearVelocity.y);
        rb.linearVelocity = movement;

        Vector3 max = box.bounds.max;
        Vector3 min = box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - 0.1f);
        Vector2 corner2 = new Vector2(min.x, min.y - 0.2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        bool grounded = false;
        if (hit)
        {
            grounded = true;
        }
        
        rb.gravityScale = (grounded && Mathf.Approximately(deltaX, 0)) ? 0 : 1;
        
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        MovingPlatform platform = null;
        if (hit)
        {
            platform = hit.GetComponent<MovingPlatform>();
        }

        if (platform)
        {
            transform.parent = platform.transform;
        }
        else
        {
            transform.parent = null;
        }
        
        anim.SetFloat("speed", Mathf.Abs(deltaX));
        
        Vector3 pScale = Vector3.one;
        if (platform)
        {
            pScale = platform.transform.localScale;
        }

        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX) / pScale.x, 1 / pScale.y, 1);
        }
    }
}
