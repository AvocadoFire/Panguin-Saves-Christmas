using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 2f;
    [SerializeField] int numberJumps = 0;
    [SerializeField] float jumpIncrease = 2f;
    [SerializeField] float gravity = 5f;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myCapsuleCollider;
    int jumps = 0;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    { 
        Run();
        FlipSprite();
        ClimbLadder();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump()
    {

        if (myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            jumps = 1;
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
        if (!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (jumps < numberJumps) 
            {
                jumps++;
                myRigidbody.velocity += new Vector2
                    (0f + jumpIncrease, 
                    myRigidbody.velocity.y + jumpSpeed);
                return; 
            }
            else { return; }
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
        if (!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myAnimator.SetBool("IsClimbing", false);
            myRigidbody.gravityScale = gravity;
            myAnimator.enabled = (true);
            return;
        }
        myAnimator.SetBool("IsClimbing", true);
        myRigidbody.gravityScale = 0;
        Vector2 climbVelocity =
            new Vector2(myRigidbody.velocity.x, climbSpeed * moveInput.y);
        myRigidbody.velocity = climbVelocity;

        bool playVertSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.enabled = (playVertSpeed);
    }
}
