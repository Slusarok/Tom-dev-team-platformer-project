using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeInShop : MonoBehaviour
{
    public PlayerController playerController;
    public AttackArea damageController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BootsOfAgility()
    {
        playerController.jumpForse += 2;
    }
    public void PureManSword()
    {
        damageController.damage += 4;
    }
    public void RingOfHumanity()
    {

    }
}
