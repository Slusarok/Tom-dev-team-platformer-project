using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public SpriteRenderer iron;
    public SpriteRenderer silver;
    public SpriteRenderer golden;
    BoxCollider2D bc2d;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Iron Key"))
        {
            Destroy(collision.gameObject);
            PlayerPrefs.SetInt("Iron Key", 1);
            iron.enabled = true;
        }
        if (collision.gameObject.CompareTag("Silver Key"))
        {
            Destroy(collision.gameObject);
            PlayerPrefs.SetInt("Silver Key", 1);
            silver.enabled = true;
        }
        if (collision.gameObject.CompareTag("Golden Key"))
        {
            Destroy(collision.gameObject);
            PlayerPrefs.SetInt("Golden Key", 1);
            golden.enabled = true;
        }
    }
}