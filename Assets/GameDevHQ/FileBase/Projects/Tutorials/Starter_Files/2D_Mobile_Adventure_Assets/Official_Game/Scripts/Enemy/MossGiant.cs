using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
   private Vector3 currentTarget;

    private Animator _anim;
    private SpriteRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    //Overrides parent Update()
    public override void Update()
    {
        if(_anim.GetCurrentAnimatorStateInfo(0).IsName("Moss_Giant_Idle"))
        {
            return;
        }

        Movement();
    }

    void Movement()
    {
        if (currentTarget == pointA.position)
        {
            _renderer.flipX = true;
        }
        else
        {
            _renderer.flipX = false; 
        }

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            _anim.SetTrigger("IdleTrigger");     
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            _anim.SetTrigger("IdleTrigger");
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}
