using UnityEngine;
using System.Collections; // <-- THIS FIXES THE ERROR

public class BowShooter : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPoint;

    public float shootDelay = 1.07f; // animation timing

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(DelayedShoot());
        }
    }

    IEnumerator DelayedShoot()
    {
        yield return new WaitForSeconds(shootDelay);
        ShootArrow();
    }

    void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
        arrow.GetComponent<Arrow>().Shoot(shootPoint.right);
    }
}
