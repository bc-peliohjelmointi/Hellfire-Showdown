using UnityEngine;

public class MeleeHitbox : MonoBehaviour
{
    public int damage = 20;
    public float knockbackForce = 8f;
    public PlayerAttack playerAttack; // reference to player attack script

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // damage
            EnemyHealth hp = other.GetComponent<EnemyHealth>();
            if (hp != null) hp.TakeDamage(damage);

            // knockback enemy only
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Push enemy in the direction the player faces
                Vector2 direction = new Vector2(playerAttack.facingDirection, 0);

                rb.linearVelocity = Vector2.zero; // reset so force is clean
                rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
            }
        }
    }
}
