using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    Rigidbody2D rb;
    //public Animator animator;
    public int damage = 3;
    public SpriteRenderer sprite;
    private void Start()
    {
        //animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
            rb = collider.GetComponent<Rigidbody2D>();
            if(sprite.flipX==false)
            {
                //animator.SetTrigger("Slam");
                rb.AddForce(new Vector2(3, 0), ForceMode2D.Impulse);
            }
            else
            {
                //animator.SetTrigger("Slam");
                rb.AddForce(new Vector2(-3, 0), ForceMode2D.Impulse);
            }

            //Debug.Log(rb);
            //Debug.Log("-3");
        }
    }
}