using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //handle to animator 
    private Animator _anim;
    // Start is called before the first frame update

    //reference to sword anim
    private Animator swordAnim;
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        swordAnim = transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
     public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move)); // takes in a float value called move. move needs an absolute value to make sure the value is always 1 instead of -1 when moving left. 
    }

    public void Jump(bool jumping)
    {
        _anim.SetBool("Jumping", jumping);
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
        swordAnim.SetTrigger("SwordArc1");
    }
}
