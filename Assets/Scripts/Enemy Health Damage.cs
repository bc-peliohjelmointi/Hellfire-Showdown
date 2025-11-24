using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Stats")]
    public float maxHealth = 50;
    private float currentHealth;

    [Header("Attack Settings")]
    public float damage = 10;                // Damage dealt to the player
    public float attackRange = 1f;         // Distance at which enemy attacks
    public float attackCooldown = 1f;
    private float nextAttackTime = 0f;

    private Transform player;

    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // Enemy attacks player when close enough
        if (distance <= attackRange && Time.time >= nextAttackTime)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
                playerHealth.TakeDamage(damage);

            nextAttackTime = Time.time + attackCooldown;
        }
    }

    // Call this when the enemy takes damage
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);   // Removes enemy
    }
}
