using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidBody;
   // BoxCollider2D myFeet;


    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidBody.velocity = new Vector2(moveSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D other) //from monster grid
    {
       if (other.CompareTag("Player")) { return; }
            moveSpeed = -1 * moveSpeed;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }

}
