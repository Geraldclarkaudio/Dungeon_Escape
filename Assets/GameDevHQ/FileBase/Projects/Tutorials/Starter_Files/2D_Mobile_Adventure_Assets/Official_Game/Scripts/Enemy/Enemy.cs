using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    //protected modifers can only be accessed by scripts that inherit from the enemy class. 
    protected int health;
    protected int speed;
    protected int gems;

    public virtual void Attack()
    {
        Debug.Log("My Name is: " + this.gameObject.name);
    }

    //Forces each script that inherits from this class to have an update.
    public abstract void Update();
}
