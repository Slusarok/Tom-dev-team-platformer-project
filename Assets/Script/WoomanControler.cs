using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoomanControler : MonoBehaviour
{
    Rigidbody2D rb;
    public LayerMask PatrulGroung;
    public Transform GrounCheck;
    public bool Right = false;
    RaycastHit2D hit;
    Animator animator;
    SpriteRenderer sprite;
    BoxCollider2D bc2d;
    public Vector2 moveVector;
    [SerializeField] float speed;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        bc2d = GetComponent<BoxCollider2D>();
    }
    //private void MovementLogic()
    //{
    //    float moveHorizontal = 5.0f;

    //    float moveVertical = 0.0f;

    //    Vector2 movement = new Vector2(moveHorizontal,  moveVertical);

    //    rb.AddForce(movement * speed);
    //}

    private void Update()
    {
        hit = Physics2D.Raycast(GrounCheck.position, -transform.up, 0.1f, PatrulGroung);
    }

    private void FixedUpdate()
    {
        if(hit.collider != false)
        {
            if(!Right)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
        else
        {
            Right = !Right;
            transform.localScale = new Vector3(-transform.localScale.x, 3.6f, 3.6f);
        }

    }
    public bool FaceStatus()
    {
        return Right;
    }
}
