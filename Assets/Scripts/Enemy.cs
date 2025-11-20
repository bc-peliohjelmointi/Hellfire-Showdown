using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyWaveManager manager;

    public void TakeDamage(int dmg)
    {
        // Tämä on vain esimerkki – käytä omaa damage-logiikkaasi
        Die();
    }

    public void Die()
    {
        manager.EnemyDied();
        Destroy(gameObject);
    }
}
