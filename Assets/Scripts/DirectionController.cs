using UnityEngine;

public class DirectionController : MonoBehaviour
{
    public float moveSpeed = 15f;
    private Rigidbody2D rb;

    public bool facingRight = true;
    private float cachedInput = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Read input here
        cachedInput = Input.GetAxisRaw("Horizontal");


    }

    void FixedUpdate()
    {
        // Move in physics update
        rb.linearVelocity = new Vector2(cachedInput * moveSpeed, rb.linearVelocity.y);
        // Flip based on input
        if (cachedInput > 0 && !facingRight) Flip();
        if (cachedInput < 0 && facingRight) Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }
}
