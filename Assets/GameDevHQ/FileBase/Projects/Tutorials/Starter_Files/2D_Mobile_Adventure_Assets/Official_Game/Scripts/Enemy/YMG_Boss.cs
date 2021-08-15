using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YMG_Boss : Enemy, IDamageable
{
    public int Health { get; set; }

    public GameObject canvas;

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
            
            audioSource.clip = attackSound[Random.Range(0,1)];
            audioSource.Play();

            anim.SetTrigger("Hit");
            isHit = true;
            anim.SetBool("inCombat", true);
        }
        else
        {
            Debug.Log("Need a better weapon!");
            StartCoroutine(TextActive());
        }

        if (Health < 1)
        {
            anim.SetTrigger("Death");
            audioSource.clip = deathSound;
            audioSource.Play();
            isDead = true;
            //Spawn a diamond
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;

            //change the value of diamond to whatever ymy gems count is. 
            diamond.GetComponent<Diamond>().gems = base.gems;

        }

        IEnumerator TextActive()
        {
            canvas.SetActive(true);
            yield return new WaitForSeconds(3.0f);
            canvas.SetActive(false);
        }
    }
}