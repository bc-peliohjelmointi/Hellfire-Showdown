using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 12f;
    public float damage = 20f;
    private Vector2 direction;

    public void Shoot(Vector2 dir)
    {
        direction = dir.normalized;

        // Flip arrow sprite visually
        Vector3 s = transform.localScale;
        s.x = Mathf.Abs(s.x) * (direction.x > 0 ? 1 : -1);
        transform.localScale = s;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ignore the player
        if (collision.gameObject.CompareTag("Player"))
            return;

        EnemyHealth hp = collision.gameObject.GetComponent<EnemyHealth>();
        if (hp != null)
            hp.TakeDamage(damage);

        Destroy(gameObject);
    }

}
