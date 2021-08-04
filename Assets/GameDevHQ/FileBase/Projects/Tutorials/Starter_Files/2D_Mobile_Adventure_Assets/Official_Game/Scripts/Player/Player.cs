using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public int diamonds = 0; 
    public int Health { get; set; }

    private Rigidbody2D rb;
   
    [SerializeField]
    private float jumpForce = 5.0f;

    [SerializeField]
    private bool isGrounded = false;

    private bool resetJumpNeeded = false;

    [SerializeField]
    private float _speed = 3.0f;

    private PlayerAnimation playerAnim;
    private SpriteRenderer _renderer;
    private SpriteRenderer _swordArcSprite;
 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimation>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        MovementReturnTypeMethod();
        Attack();             
    }

    void MovementReturnTypeMethod()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");//define horizontal input 
        isGrounded = Grounded();
        
        //FLIP SPRITE=============
        if(horizontalMovement > 0)
        {
            Flip(true);
        }
        else if(horizontalMovement < 0)
        {
            Flip(false);
        }
        //JUMP LOGIC======================================
        if(Input.GetKeyDown(KeyCode.Space) && Grounded() == true)
        {
            // jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            StartCoroutine(WaitForGrounded());
            playerAnim.Jump(true);
        }
         //MOVE==============================================================
        rb.velocity = new Vector2(horizontalMovement * _speed, rb.velocity.y);
        //Change Animation state =================================
        playerAnim.Move(horizontalMovement);//Call the Move method from player anaim and set the float value equal to our horizontal input. 
    }

    bool Grounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, 1 << 8);

        Debug.DrawRay(transform.position, Vector2.down * 1.0f, Color.green);

        if(hitInfo.collider != null)
        {
            if(resetJumpNeeded == false)
            {
                playerAnim.Jump(false);
                return true;
            }
        }

        return false;
    }

    void Flip(bool faceRight)
    {
        if(faceRight == true) // if facing right is true
        {
            _renderer.flipX = false; // not flipping x on the player sprite
            _swordArcSprite.flipX = false; // not flipping X or Y on sword arc
            _swordArcSprite.flipY = false;

            Vector3 newPos = _swordArcSprite.transform.localPosition; // temporary variable 
            newPos.x = 1.01f; // setting x of new Pos to 1.01
            _swordArcSprite.transform.localPosition = newPos;//then saying new position is newPos + what we just did for X 
        }
        else if(faceRight == false)
        {
            _renderer.flipX = true;
            _swordArcSprite.flipX = true;
            _swordArcSprite.flipY = true;

            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = -1.01f;
            _swordArcSprite.transform.localPosition = newPos;
        }
    }

    public void Damage()
    {
        if(Health < 1)
        {
            return;
        }
        Debug.Log("Damage() called on player");
        //remove 1 health 
        Health--;
        UIManager.Instance.UpdateLives(Health);

        if(Health < 1)
        {
            playerAnim.Death();
        }
        //Update UI display. 
        //check if dead
        //play death anim 
        //Update UI display. 
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
            resetJumpNeeded = true;
            yield return new WaitForSeconds(0.1f);
            resetJumpNeeded = false;
        
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0) && Grounded() == true)
        {
            playerAnim.Attack();
        }
    }

    public void CollectDiamond()
    {
        diamonds++;
    }

    public void AddGems(int amount)
    {
        diamonds += amount;
        UIManager.Instance.UpdateGemCount(diamonds);
    }


}
