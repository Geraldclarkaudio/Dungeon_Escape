using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YMG_Boss : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();
    }


    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }

        if(GameManager.Instance.hasFlameSword == true)
        {
            Health--;
            anim.SetTrigger("Hit");
            isHit = true;
            anim.SetBool("inCombat", true);
        }
        else
        {
            Debug.Log("Need a better weapon!");
            //UIManager saying you need to get flamesword

        }

        if (Health < 1)
        {
            anim.SetTrigger("Death");
            isDead = true;
            //Spawn a diamond
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;

            //change the value of diamond to whatever ymy gems count is. 
            diamond.GetComponent<Diamond>().gems = base.gems;

        }
    }
}