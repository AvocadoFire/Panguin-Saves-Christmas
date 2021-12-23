using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeedY = 5f;
    [SerializeField] float climbSpeed = 2f;
    [SerializeField] int maxJumps = 1;
 //   [SerializeField] float jumpIncreaseX = 2f;
    [SerializeField] float gravity = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(10f, 10f);

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    int jumpsLeft = 0;
    bool isAlive = true;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (!isAlive) { return;}
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }

    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
    }

    void OnJump()
    {
        if (!isAlive) { return; }

        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            jumpsLeft = maxJumps;
         myRigidbody.velocity += new Vector2(0f, jumpSpeedY);
         --jumpsLeft;
            Debug.Log(jumpsLeft);
        }

        else
        {
            if (jumpsLeft <= 0) 
            { return; }
            myRigidbody.velocity += new Vector2(0f, jumpSpeedY);
            --jumpsLeft;
            Debug.Log(jumpsLeft);
        }

    }

    void Run()
    {
        Vector2 playerVelocity = 
            new Vector2(runSpeed * moveInput.x, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    
    }


    void FlipSprite()
    {
        bool playHorizSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playHorizSpeed)
            {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1);
            myAnimator.SetBool("IsRunning", true);
            }
   
        else
            myAnimator.SetBool("IsRunning", false);
    }

    void ClimbLadder()
    {
        if (!myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myAnimator.SetBool("IsClimbing", false);
            myRigidbody.gravityScale = gravity;
            myAnimator.enabled = (true);
            return;
        }
        myAnimator.SetBool("IsClimbing", true);
        myRigidbody.gravityScale = .1f;
        Vector2 climbVelocity =
            new Vector2(myRigidbody.velocity.x, climbSpeed * moveInput.y);
        myRigidbody.velocity = climbVelocity;

        bool playVertSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.enabled = (playVertSpeed);
    }

    void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
        {
            isAlive = false;
            myAnimator.SetTrigger("IsDying");
            myRigidbody.velocity = deathKick;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            jumpsLeft = maxJumps;
            Debug.Log(jumpsLeft);
        }
    }

}
