using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    // Start is called before the first frame update
    void Start()
    {   
        Attack();
    }

    public override void Attack()
    {
        Debug.Log("Spider Attack");
    }

    //Overrides parent update method
    public override void Update()
    {
        Debug.Log("Spider Updating...");
    }

}
