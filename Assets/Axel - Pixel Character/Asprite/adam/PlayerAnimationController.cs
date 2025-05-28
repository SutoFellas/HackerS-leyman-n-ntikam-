using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public float moveThreshold = 0.1f;
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask whatIsGround;
    private bool isGrounded;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Hareket animasyonu kontrolü
        float horizontalVelocity = rb.linearVelocity.x;
        bool isMoving = Mathf.Abs(horizontalVelocity) > moveThreshold;
        animator.SetBool("isMoving", isMoving);

        // Karakterin yönünü ayarla
        if (horizontalVelocity > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalVelocity < 0)
        {
            spriteRenderer.flipX = true;
        }

        // Zıplama kontrolü
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        animator.SetBool("isJumping", !isGrounded);
    }
}