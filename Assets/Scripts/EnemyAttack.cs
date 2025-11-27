using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;
    public float attackCooldown = 1f;

    private float nextAttackTime = 0f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time < nextAttackTime)
            return;

        PlayerHealth ph = other.GetComponent<PlayerHealth>();

        if (ph != null)
        {
            ph.TakeDamage(damage);
            nextAttackTime = Time.time + attackCooldown;

          
        }
    }
}
