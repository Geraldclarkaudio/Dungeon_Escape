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
        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        Vector3 direction = player.transform.localPosition - transform.localPosition;

        //Debug.Log("Distance: " + distance);

        if(direction.x > 0 && anim.GetBool("inCombat") == true)
        {
            //face right
            sprite.flipX = false;
        }
        else if(direction.x < 0 && anim.GetBool("inCombat") == true)
        {
            //face left 
            sprite.flipX = true;
        }
    }

    public void Damage()
    {
       
        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("inCombat", true);
        if(Health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
