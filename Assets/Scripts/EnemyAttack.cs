using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;
    public float attackCooldown = 1f;

    private float nextAttackTime = 0f;
<<<<<<< Updated upstream
=======
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }
>>>>>>> Stashed changes

    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player == null) return;

        if (Time.time >= nextAttackTime)
        {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            ph.TakeDamage(damage);
            nextAttackTime = Time.time + attackCooldown;

          
=======
            // Deal damage
            player.TakeDamage(damage);

            // Trigger attack animation
            animator.SetTrigger("Attacking");

            // New cooldown
            nextAttackTime = Time.time + attackCooldown;
>>>>>>> Stashed changes
=======
            // Deal damage
            player.TakeDamage(damage);

            // Trigger attack animation
            animator.SetTrigger("Attacking");

            // New cooldown
            nextAttackTime = Time.time + attackCooldown;
>>>>>>> Stashed changes
        }
    }
}
