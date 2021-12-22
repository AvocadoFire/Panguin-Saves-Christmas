using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myCapsuleCollider;

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
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump()
    {
        if (!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {return;}
        myRigidbody.velocity += new Vector2(0f, jumpSpeed);
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
}
