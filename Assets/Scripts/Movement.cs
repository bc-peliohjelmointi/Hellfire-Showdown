using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Attack")]
    public float attackCooldown = 0.3f;
    private float attackTimer = 0f;

    private Rigidbody2D rb;
    private Animator anim;

    private float moveInput;
    private bool isGrounded;
    private bool isAttacking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        // Animator ground/jump logic
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetBool("IsJumping", !isGrounded);

        // Attack cooldown
        if (attackTimer > 0f)
            attackTimer -= Time.deltaTime;

        // ATTACK
        if (Input.GetKeyDown(KeyCode.J) && attackTimer <= 0f && !isAttacking)
        {
            Attack();
        }

        // Stop movement during attack
        if (isAttacking)
        {
            anim.SetFloat("Speed", 0);
            return;
        }

        // MOVEMENT
        moveInput = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // FLIP CHARACTER
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // JUMP
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // RUN ANIMATION
        anim.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    void Attack()
    {
        isAttacking = true;
        attackTimer = attackCooldown;

        anim.SetTrigger("Attack");

        // match your animation length
        Invoke(nameof(EndAttack), 0.3f);
    }

    void EndAttack()
    {
        isAttacking = false;
    }
}
