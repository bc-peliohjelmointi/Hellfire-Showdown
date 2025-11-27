using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float damage = 25f;  // how much damage this arrow deals
    public float speed = 10f;
    public float lifeTime = 3f;

    private Vector2 direction;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void Shoot(Vector2 dir)
    {
        direction = dir.normalized;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        // Rotate arrow based on direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        // Check if the object has a health script
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
