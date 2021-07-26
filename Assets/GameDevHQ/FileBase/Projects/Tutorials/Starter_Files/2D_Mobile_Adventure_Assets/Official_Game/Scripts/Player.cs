using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    private Rigidbody2D rb;
   
    [SerializeField]
    private float jumpForce = 5.0f;

    [SerializeField]
    private bool isGrounded = false;

    private bool resetJumpNeeded = false;

    [SerializeField]
    private float _speed = 3.0f;

 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement();
        //CheckGrounded();

        //Return type method 
        MovementReturnTypeMethod();
        Grounded();
    }

    void MovementReturnTypeMethod()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizontalMovement * _speed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && Grounded() == true)
        {
            // jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            StartCoroutine(WaitForGrounded());
        }
    }

    bool Grounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, 1 << 8);

        Debug.DrawRay(transform.position, Vector2.down * 1.0f, Color.green);

        if(hitInfo.collider != null)
        {
            if(resetJumpNeeded == false)
            {
                return true;
            }
        }

        return false;
    }

   /* void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");

        //if space key && grounded. 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            // breathe
            resetJumpNeeded = true;
            StartCoroutine(WaitForGrounded());
        }
        rb.velocity = new Vector2(move, rb.velocity.y);
    }

   void CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8); //using bit shift because it was originally detecting the player. 
        //COuld also set a LayerMask variable called _groundLayer and instead of using bit shift use _groundLayer.value. 
        Debug.DrawRay(transform.position, Vector2.down, Color.green);

        if (hit.collider != null)
        {
            Debug.Log("Hit" + hit.collider.name);
            if (resetJumpNeeded == false)
            {
                isGrounded = true;

            }
        }
    } */
    IEnumerator WaitForGrounded()
    {
        
            yield return new WaitForSeconds(0.1f);
            resetJumpNeeded = false;
        
    }


}