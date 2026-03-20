using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 8f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private float moveInput;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ← → input
        moveInput = Input.GetAxisRaw("Horizontal");

        // Flip gauche/droite (CORRIGÉ !)
        if (moveInput > 0.1f)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (moveInput < -0.1f)
            transform.localScale = new Vector3(-1f, 1f, 1f);  // Y = 1f MAINTENANT !


        // Check sol
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Saut ESPACE
        if (Input.GetButtonDown("Jump") && isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        // ANIMATION : Speed vers Animator
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    void FixedUpdate()
    {
        // Mouvement fluide
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }
}
