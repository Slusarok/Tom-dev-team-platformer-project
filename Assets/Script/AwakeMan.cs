using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeMan : MonoBehaviour
{
    Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    BoxCollider2D bc2d;
    public GameObject go;
    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //sprite = GetComponent<SpriteRenderer>();
        bc2d = GetComponent<BoxCollider2D>();
        //go = GetComponent<GameObject>();
        //go.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            spriteRenderer.enabled = true;
            Debug.Log("ALARM");
            animator.SetBool("Awake",true);
        }
        else
        {
            animator.SetBool("Awake", false);
        }
        
    }
}
