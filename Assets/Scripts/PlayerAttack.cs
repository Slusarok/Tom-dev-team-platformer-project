using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] SpriteRenderer MainHeroSprite;
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
        MainHeroSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
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
                if(MainHeroSprite.flipX == false)
                    attackAreaLeft.SetActive(attacking);
                else
                    attackAreaRight.SetActive(attacking);
            }

        }
    }

    private void Attack()
    {
        attacking = true;
        if (MainHeroSprite.flipX==false)
            attackAreaLeft.SetActive(attacking);
        else
            attackAreaRight.SetActive(attacking);
    }
}