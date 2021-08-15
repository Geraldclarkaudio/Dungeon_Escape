using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
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
        if(isDead == true)
        {
            return;
        }

        Health--;
        audioSource.clip = attackSound[Random.Range(0,1)];
        audioSource.pitch = Random.Range(0.7f, 1.2f);
        audioSource.Play();
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("inCombat", true);

        if (Health < 1)
        {
            anim.SetTrigger("Death");
            isDead = true;
            audioSource.pitch = 1f;
            audioSource.clip = deathSound;
            audioSource.Play();
            //Spawn a diamond
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;

            //change the value of diamond to whatever ymy gems count is. 
            diamond.GetComponent<Diamond>().gems = base.gems; 

        }
    }
}
