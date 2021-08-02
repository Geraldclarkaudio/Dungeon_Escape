using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    [SerializeField]
    private GameObject acidPrefab;
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public void Damage()
    {
        Health--;
        if(Health < 1)
        {
            anim.SetTrigger("Death");
            isDead = true;
        }
    }
    public override void Movement()
    {
        //sit still
    }
    public override void Update()
    {
       //dont use Update of Enemy Class

    }

    public void Attack()
    {
        //instantiate acid 
        Instantiate(acidPrefab, transform.position, Quaternion.identity);
    }

}
