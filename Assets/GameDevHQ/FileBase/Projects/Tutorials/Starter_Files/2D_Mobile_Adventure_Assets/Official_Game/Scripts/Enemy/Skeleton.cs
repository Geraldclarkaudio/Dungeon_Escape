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
        if (isDead == true)
        {
            return;
        }

        Health--;
        anim.SetTrigger("Hit");
        audioSource.clip = attackSound[Random.Range(0,1)];
        audioSource.Play();
        isHit = true;
        anim.SetBool("inCombat", true);
        if(Health < 1)
        {
            anim.SetTrigger("Death");
            audioSource.clip = deathSound;
            audioSource.Play();
            isDead = true;
            //Spawn a diamond
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;

            //change the value of diamond to whatever ymy gems count is. 
            diamond.GetComponent<Diamond>().gems = base.gems; ;
        }
    }
}
