using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPoint;

    public float shootDelay = 1.05f;
    public float shootCooldown = 1.2f;

    private bool canShoot = true;
    private DirectionController direction;

    void Start()
    {
        direction = GetComponent<DirectionController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && canShoot)
        {
            StartCoroutine(DelayedShoot());
        }
    }

    IEnumerator DelayedShoot()
    {
        canShoot = false;

        yield return new WaitForSeconds(shootDelay);
        ShootArrow();

        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }

    void ShootArrow()
    {
        // Cache shoot direction instantly
        Vector2 dir = direction.facingRight ? Vector2.right : Vector2.left;

        // Cache shoot position instantly (before physics updates)
        Vector3 spawnPos = shootPoint.position;

        // Spawn arrow
        GameObject arrow = Instantiate(arrowPrefab, spawnPos, Quaternion.identity);

        // Shoot
        arrow.GetComponent<Arrow>().Shoot(dir);
    }
}
