using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeMan : MonoBehaviour
{
    Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    BoxCollider2D bc2d;
    public Animator animator;
    public PlayerController checkStatus;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        checkStatus.Hidden = false;
    }
    void FixedUpdate()
    {
        Debug.Log(checkStatus.GetStatus());
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (!checkStatus.GetStatus())
        //{
            if (collision.gameObject.CompareTag("PatrulWoman"))
            {
                checkStatus.Hidden = false;
                spriteRenderer.enabled = true;
                Debug.Log("ALARM");
                animator.SetBool("Awake", true);   
            }
            else
            {
                animator.SetBool("Awake", false);
            }
        //}
        //else if (checkStatus.GetStatus())
        //{
        //    animator.SetBool("Awake", false);

        //}

    }
}
