using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;              // Enemy movement speed
    public Transform target;                  // Player target
    private Animator animator;                // Reference to Animator

    void Start()
    {
        // Get Animator component
        animator = GetComponent<Animator>();

        // Automatically find player by tag
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                target = player.transform;
        }
    }

    void Update()
    {
        if (target == null) return;

        // Move toward the target
        Vector2 direction = (target.position - transform.position).normalized;

        // Apply movement
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

        // Animation: send speed to Animator
        animator.SetFloat("Speed", direction.magnitude);

        // Optional: Flip sprite depending on direction
        if (direction.x != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(direction.x) * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }
}
