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
        if (isDead == true)
        {
            return;
        }
        Health--;
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
        float distance = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log("you are " + distance + "units away");
        AudioSource.PlayClipAtPoint(attackSound[0], transform.position);
        
       


    }

}
