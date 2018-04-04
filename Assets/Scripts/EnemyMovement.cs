using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float slowestSpeed = 0.5f;
    [SerializeField] float fastestSpeed = 2f;

    float moveSpeed;
    Rigidbody2D myRigidBody;
    PlayerMovement playerMovement;

    private void Start()
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
        if (IsFacingLeft())
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }
    } 

    bool IsFacingLeft()
    {
        return transform.localScale.x < 0;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Flip sprite
        transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            playerMovement.collidedWithEnemy = true;
        }
    }
}
