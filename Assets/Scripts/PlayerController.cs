using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sprite;
    BoxCollider2D bc2d;
    public float jumpForse;
    bool isGround;
    bool isSaveZone;
    bool isShop;
    public GameObject ShopButton;
    public Transform groundCheck;
    public Transform saveZoneCheck;
    public Transform ShopCheck;
    public float checkRadius;
    public LayerMask whatISground;
    public LayerMask whatIsSaveZone;
    public LayerMask whatIsShop;
    private int extraJump;
    public int extraJumpValue;
    public Vector2 moveVector;
    public bool Hidden;
    [SerializeField] int speed;
    float horizontalSpeed;
    [SerializeField] float Speed_;
    private void Start()
    {
        ShopButton.SetActive(false);
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
        isSaveZone = Physics2D.OverlapCircle(saveZoneCheck.position, checkRadius, whatIsSaveZone);
        isShop = Physics2D.OverlapCircle(ShopCheck.position, checkRadius, whatIsShop);

        if (isShop)
        {
            ShopButton.SetActive(true);
        }
        //else
        //{
        //    ShopButton.SetActive(false);
        //}

        if (Input.GetKey(KeyCode.W) && isSaveZone==true)
        {
            Hidden = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            sprite.color = new Color(0, 0, 0);
            Debug.Log("savezon");
        }

        else if (Input.GetKey(KeyCode.S) && isSaveZone == true)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            sprite.color = new Color(255, 255, 255);
            Hidden = false;
            Debug.Log("NOsavezon");
        }

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
            Hidden = true;
            animator.SetBool("isSlinking", false);
            animator.SetBool("isRunning", false);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        transform.Translate(horizontalSpeed, 0, 0);
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
    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("SaveDoor"))
    //    {
            
    //        if (Input.GetKey(KeyCode.W))
    //        {
    //            Hidden = true;
    //            Debug.Log("savezon");    
    //        }
    //        else if (Input.GetKey(KeyCode.S))
    //        {
                
    //            Hidden = false;
    //            Debug.Log("NOsavezon");
    //        }
    //    }
    //}
}
