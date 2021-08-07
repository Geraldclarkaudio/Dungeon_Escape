using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    //handle to animator 
    //fuck 
    private Spider _spider;

    private void Start()
    {
        _spider = transform.parent.GetComponentInParent<Spider>();
    }
    public void Fire()
    {
        _spider.Attack();
        //tell spider to fire.
    }
}
