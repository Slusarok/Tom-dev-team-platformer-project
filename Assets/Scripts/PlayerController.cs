using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sprite;
    BoxCollider2D bc2d;
    public float jumpForse;
    bool isGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatISground;
    private int extraJump;
    public int extraJumpValue;
    public Vector2 moveVector;
    public bool Hidden;
    [SerializeField] int speed;
    float horizontalSpeed;
    [SerializeField] float Speed_;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        bc2d = GetComponent<BoxCollider2D>();
        extraJump = extraJumpValue;
        Hidden = false;
    }

    private void Update()
    {
        if (isGround == true)
        {
            extraJump = extraJumpValue;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {
            animator.SetTrigger("Jump");
            rb.velocity = Vector2.up * jumpForse;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGround == true)
        {
            animator.SetTrigger("Jump");
            rb.velocity = Vector2.up * jumpForse;
        }
    }
    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatISground);

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isSlinking", false);
            animator.SetBool("isRunning", true);
            rb.velocity = new Vector2(speed, rb.velocity.y);
            sprite.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isSlinking", false);
            animator.SetBool("isRunning", true);
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            sprite.flipX = true;
        }
        //else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.A))
        else if (Input.GetKey(KeyCode.Q))
        {
            Hidden = true;
            animator.SetBool("isRunning", false);
            animator.SetBool("isSlinking", true);
            rb.velocity = new Vector2(-speed/2, rb.velocity.y);
            sprite.flipX = true;
        }
        else if (Input.GetKey(KeyCode.E))
        //else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.D))
        {
            Hidden = true;
            animator.SetBool("isRunning", false);
            animator.SetBool("isSlinking", true);
            rb.velocity = new Vector2(speed/2, rb.velocity.y);
            sprite.flipX = false;
        }
        else
        {
            Hidden = false;
            animator.SetBool("isSlinking", false);
            animator.SetBool("isRunning", false);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        transform.Translate(horizontalSpeed, 0, 0);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        rb.gravityScale = 1;
    }
    public void JumpButton()
    {
        if (isGround == true)
        {
            extraJump = extraJumpValue;
        }
        if (extraJump > 0)
        {
            animator.SetTrigger("Jump");
            rb.velocity = Vector2.up * jumpForse;
        }
        else if (extraJump == 0 && isGround == true)
        {
            animator.SetTrigger("Jump");
            rb.velocity = Vector2.up * jumpForse;
        }
    }
    public bool GetStatus()
    {
        return Hidden;
    }
}
