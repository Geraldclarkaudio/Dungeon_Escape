using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        //assign Health
        Health = base.health;
    }
    public override void Movement()
    {
        base.Movement();
    }

    public void Damage()
    {
       
        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("inCombat", true);
        if(Health < 1)
        {
            anim.SetTrigger("Death");
            isDead = true;
        }
    }
}
