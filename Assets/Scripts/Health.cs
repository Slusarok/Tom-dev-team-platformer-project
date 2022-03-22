using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject DeathPanel;
    [SerializeField] private int health = 100;

    private int MAX_HEALTH = 100;
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //Damage(10);
        //}

        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    // Heal(10);
        //}
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if (wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    private void Die()
    {
        if (gameObject.name == "MainHero")
        {
            gameObject.SetActive(false);
            Debug.Log("gameover");
            Time.timeScale = 0;
            DeathPanel.SetActive(true);
        }
        else
        {
            Debug.Log("You Kill citizen");
            gameObject.SetActive(false);
            
        }
        

        
    }
}