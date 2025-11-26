using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject meleeArea;    // Drag your melee area object here
    public float attackDuration = 0.1f; // How long the hitbox stays active
    public float attackCooldown = 0.3f; // Time between attacks
    public int facingDirection = 1; // 1 = right, -1 = left

    private bool canAttack = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && canAttack)   // Attack key
        {
            StartCoroutine(DoMeleeAttack());
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
            facingDirection = 1;
        else if (Input.GetAxisRaw("Horizontal") < 0)
            facingDirection = -1;
    }

    private System.Collections.IEnumerator DoMeleeAttack()
    {
        canAttack = false;

        meleeArea.SetActive(true);        // Turn hitbox on
        yield return new WaitForSeconds(attackDuration);
        meleeArea.SetActive(false);       // Turn hitbox off

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
