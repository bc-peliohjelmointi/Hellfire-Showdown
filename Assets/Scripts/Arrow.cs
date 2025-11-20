using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;

    private Vector2 direction;

    public void Shoot(Vector2 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, lifeTime); // auto-despawn
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        // Rotate arrow based on direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Add hit logic here
        Debug.Log("Hit: " + collision.name);
        Destroy(gameObject);
    }
}
