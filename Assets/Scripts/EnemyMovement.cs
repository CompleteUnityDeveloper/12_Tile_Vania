using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// note this is doing more than enemy movement
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float slowestSpeed = 0.5f;
    [SerializeField] float fastestSpeed = 2f;

    bool facingRight = false; // todo remove unneessary cache
    float moveSpeed = 0f;

    Rigidbody2D myRigidBody;
    PlayerMovement playerMovement;

    void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        moveSpeed = Random.Range(slowestSpeed, fastestSpeed);
    }
    
    void Update ()
    {
        MoveHorizontally();        
    }

    void MoveHorizontally()
    {
        if (facingRight)
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }
    } 

    void OnTriggerExit2D(Collider2D other)
    {
        facingRight = !facingRight;
        transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
    }

    void OnTriggerEnter2D(Collider2D other) // thou shalt copy and paste messages
    {
        if (other.gameObject.name == "Player")
        {
            playerMovement.collidedWithEnemy = true;
        }
    }
}
