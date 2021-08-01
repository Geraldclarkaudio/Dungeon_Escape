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


    public virtual void Attack()
    {
        
    }

    //Forces each script that inherits from this class to have an update.
    public abstract void Update();
}
