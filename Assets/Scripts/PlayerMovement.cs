using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private float horizontalInput;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 1. Get Input (GetAxisRaw makes movement snappy instead of floaty)
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // 2. Update Animator
        // We use Mathf.Abs to always pass a positive number for speed
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // 3. Flip Sprite based on direction
        if (horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        // Apply movement velocity while preserving vertical (falling) velocity
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f; // Invert the X scale to flip the sprite
        transform.localScale = localScale;
    }
}