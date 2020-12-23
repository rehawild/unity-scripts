using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float movementSpeed = 0.3f;
    [SerializeField] float jumpForce = 0.21f;
    [SerializeField] bool isGrounded;
    [SerializeField] bool onPlatform;


    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        animatonControl();
        Movement();
        Jump();
    }

    void Movement()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime, 0f, 0f);
        if (Input.GetAxisRaw("Horizontal") != 0)
            animator.SetBool("isRunning", true);
        else
            animator.SetBool("isRunning", false);

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.W) && isGrounded || Input.GetKey(KeyCode.W) && onPlatform)
        {

            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            isGrounded = true;
        if (collision.collider.tag == "Platform")
            onPlatform = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            isGrounded = false;
        if (collision.collider.tag == "Platform")
            onPlatform = false;
    }

    void animatonControl()
    {
        if (rb.velocity.y > 0f)
        {
            animator.SetBool("isFalling", false);
            animator.SetBool("isJumping", true);
        }
        if (rb.velocity.y < 0f)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }
        if (rb.velocity.y == 0f)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }

    }
}
