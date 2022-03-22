using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManController : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;
    SpriteRenderer sprite;
    BoxCollider2D bc2d;
    public float speed;
    Transform player;
    
    public PlayerController checkStatus;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        bc2d = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sprite.enabled== true /*&& checkStatus.Hidden==false*/)
        {
            if(player.position.x - transform.position.x >= 0 && checkStatus.Hidden == false)
            {
                sprite.flipX=false;
                animator.SetBool("Walking",true);
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if(player.position.x - transform.position.x <= 0 && checkStatus.Hidden == false)
            {
                sprite.flipX = true;
                animator.SetBool("Walking", true);
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                
                transform.Translate(0, 0, 0);
            }
        }
        
    }
}
