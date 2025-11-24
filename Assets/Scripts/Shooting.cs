using UnityEngine;
using System.Collections;

public class BowShooter : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPoint;

    public float shootDelay = 1.05f;  // time until release in animation
    public float shootCooldown = 1.2f; // time between shots
    private bool canShoot = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && canShoot)
        {
            Debug.Log("Pressed shoot!");
            StartCoroutine(DelayedShoot());
        }
    }

    IEnumerator DelayedShoot()
    {
        canShoot = false; // lock shooting
        Debug.Log("Coroutine started");

        yield return new WaitForSeconds(shootDelay);
        Debug.Log("Reached shoot moment");

        ShootArrow();

        // cooldown after the arrow fires
        yield return new WaitForSeconds(shootCooldown);
        Debug.Log("Cooldown finished");
        canShoot = true;
    }

    void ShootArrow()
    {
        Debug.Log("Shooting arrow!"); // check if this fires
        GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
        arrow.GetComponent<Arrow>().Shoot(shootPoint.right);
    }
}
