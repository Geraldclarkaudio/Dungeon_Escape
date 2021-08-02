using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    //protected modifers can only be accessed by scripts that inherit from the enemy class. 
    
    //GENERA STATS===================
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    //WAYPOINTS=======================
    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;

    protected Player player;
    protected bool isDead = false;
    //Variable to store player position

    //DamageRelated Stuff
    protected bool isHit = false;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("inCombat") == false || isDead == true)
        {
            return;
        }
        Movement();
    }

    public virtual void Movement()
    {
        if (currentTarget == pointA.position)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("IdleTrigger");
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("IdleTrigger");
        }

        if(isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }


        //CHECK DISTANCE BETWEEN PLAYER AND THIS. ================================================================
        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        
        if(distance > 2.0f)
        {
            isHit = false;
            anim.SetBool("inCombat", false);
        }

        //FLIP SPRITE WHILE IN COMBAT DEPENDING ON DIRECTION VARIABLE =============================================

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (direction.x > 0 && anim.GetBool("inCombat") == true)
        {
            //face right
            sprite.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("inCombat") == true)
        {
            //face left 
            sprite.flipX = true;
        }
    }
}