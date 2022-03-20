using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackAreaLeft = default;
    private GameObject attackAreaRight = default;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackAreaLeft= transform.GetChild(2).gameObject;
        attackAreaRight = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackAreaLeft.SetActive(attacking);
                attackAreaRight.SetActive(attacking);
            }

        }
    }

    private void Attack()
    {
        attacking = true;
        attackAreaLeft.SetActive(attacking);
        attackAreaRight.SetActive(attacking);
    }
}