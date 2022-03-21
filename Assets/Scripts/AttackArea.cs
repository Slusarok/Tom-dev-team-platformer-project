using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    Rigidbody2D rb;
    private int damage = 3;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
            rb = collider.GetComponent<Rigidbody2D>();
            //rb.AddForce(new Vector2(10, 10),ForceMode2D.Force);
            //Debug.Log(rb);
            Debug.Log("-3");
        }
    }
}