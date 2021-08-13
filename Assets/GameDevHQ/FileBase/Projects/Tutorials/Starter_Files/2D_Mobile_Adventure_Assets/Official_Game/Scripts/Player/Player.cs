using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

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

    public GameObject gameOverText;
    public GameObject gameOverFade;

    public GameObject cantMakeItBox;
 

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
        if(Health > 1)
        {
            MovementReturnTypeMethod();
            Attack();
        }

        if (Health < 1)
        {

            GameOver();
        }
    }

    void MovementReturnTypeMethod()
    {
        float horizontalMovement = CrossPlatformInputManager.GetAxis("Horizontal");//define horizontal input 
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
        if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("A_Button")) && Grounded() == true)
        {
            if (GameManager.Instance.hasBootsOfFlight == true) //Boots Of Flight Jump
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce + 3f);
                StartCoroutine(WaitForGrounded());
                playerAnim.Jump(true);
            }
            else // REGULAR JUMP
            {
                // jump
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                StartCoroutine(WaitForGrounded());
                playerAnim.Jump(true);
            }
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

        Health--;
        UIManager.Instance.UpdateLives(Health);

        if(Health < 1)
        {
            playerAnim.Death();
        }
    }
    void Attack()
    {
        if (Input.GetKeyDown((KeyCode.F)) || CrossPlatformInputManager.GetButtonDown("B_Button") && Grounded() == true)
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Spikes")
        {
            Debug.Log("Collision with Spikes Detected");

            Health -= 5;
            playerAnim.Death();
        }

        if(other.tag == "CantMakeThat" && GameManager.Instance.hasBootsOfFlight == false)
        {
            //set active 
            cantMakeItBox.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "CantMakeThat")
        {
            cantMakeItBox.SetActive(false);
        }
    }

    public void GameOver()
    { 
        StartCoroutine(GameOverFlicker());
        gameOverFade.SetActive(true);
    }


    IEnumerator WaitForGrounded()
    {
            resetJumpNeeded = true;
            yield return new WaitForSeconds(0.1f);
            resetJumpNeeded = false;  
    }

    IEnumerator GameOverFlicker()
    {
        yield return new WaitForSeconds(0.5f);
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        GameManager.Instance.gameOver = true;
    }




}
