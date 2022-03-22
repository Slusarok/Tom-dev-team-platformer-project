using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLvl : MonoBehaviour
{
    public GameObject WinPanel;
    Rigidbody2D rb;
    public Animator animator;
    BoxCollider2D bc2d;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
    }
    public void animgate()
    {
        animator.Play("OpenGate");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EndLvlOne"))
        {
            if(PlayerPrefs.GetInt("Iron Key")==1 && PlayerPrefs.GetInt("Silver Key") == 1 && PlayerPrefs.GetInt("Golden Key") == 1)
            {
                animator.SetTrigger("OpenGate");
                //Time.timeScale = 0;
                WinPanel.SetActive(true);
            }
        }
    }
    }
