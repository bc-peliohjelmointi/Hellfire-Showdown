using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyWaveManager manager;

    public int health = 1;

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
            Die();
    }

    void Die()
    {
        manager.EnemyDied();
        Destroy(gameObject);
    }
}
