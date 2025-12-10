using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;
    public float attackCooldown = 1f;

    private float nextAttackTime = 0f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time < nextAttackTime)
            return;

        PlayerHealth ph = other.GetComponent<PlayerHealth>();

        if (ph != null)
        {
            // Play attack animation
            animator.SetBool("Melee", true);

            // Deal damage
            ph.TakeDamage(damage);

            // Start cooldown
            nextAttackTime = Time.time + attackCooldown;

            // Stop the attack animation after a short moment
            StartCoroutine(StopAttackAnimation());
        }
    }

    private System.Collections.IEnumerator StopAttackAnimation()
    {
        yield return new WaitForSeconds(0.2f); // depends on your attack animation length
        animator.SetBool("IsAttacking", false);
    }
}
