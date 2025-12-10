using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 50;
    private float currentHealth;
    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        Debug.Log("Enemy took " + amount + " damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        // Play death animation
        if (animator != null)
            animator.SetBool("Death", true);

        // Disable enemy scripts while animation plays
        GetComponent<EnemyMovement>().enabled = false;
        if (GetComponent<EnemyAttack>() != null)
            GetComponent<EnemyAttack>().enabled = false;

        // Destroy the enemy after animation ends (delay depends on your animation length)
        Destroy(gameObject, 1.0f);
    }
}
