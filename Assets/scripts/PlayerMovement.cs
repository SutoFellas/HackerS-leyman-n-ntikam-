using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float normalSpeed = 5f;
    public float normalJumpForce = 5f;
    private float currentSpeed;
    private float currentJumpForce;
    private Rigidbody2D rb;
    private bool isGrounded;
    private float normalGravity;

    public Transform groundCheck; // Inspector'dan ayarlayacaksın
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;

    private bool isSpeedPowerUpActive = false;
    private float sliderSpeed = 5f; // Slider'dan gelen son hız değeri

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = normalSpeed;
        currentJumpForce = normalJumpForce;
        normalGravity = rb.gravityScale;
    }

    void Update()
    {
        // Hareket
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * currentSpeed, rb.linearVelocity.y);

        // Zıplama
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, currentJumpForce);
        }
    }

    // PowerUp'ları aktifleştir
    public void ActivateSpeedBoost()
    {
        isSpeedPowerUpActive = true;
        currentSpeed = normalSpeed * 1.5f;
    }

    public void ActivateJumpBoost()
    {
        Debug.Log("JumpBoost Aktif!");
        currentJumpForce = normalJumpForce * 1.5f;
    }

    public void ActivateLowGravity()
    {
        rb.gravityScale = normalGravity * 0.5f;
    }

    // PowerUp'ları deaktif et
    public void DeactivateSpeedBoost()
    {
        isSpeedPowerUpActive = false;
        // Power-up bitince slider'daki değeri uygula
        normalSpeed = sliderSpeed;
        currentSpeed = sliderSpeed;
    }

    public void DeactivateJumpBoost()
    {
        currentJumpForce = normalJumpForce;
    }

    public void DeactivateLowGravity()
    {
        rb.gravityScale = normalGravity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void SetSpeed(float speed)
    {
        sliderSpeed = speed;
        if (!isSpeedPowerUpActive)
        {
            normalSpeed = speed;
            currentSpeed = speed;
        }
    }
} 