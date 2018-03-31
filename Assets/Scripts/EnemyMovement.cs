using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    float moveSpeed = 0f;
    [SerializeField] float slowestSpeed = 0.5f;
    [SerializeField] float fastestSpeed = 2f;

    bool facingRight = false;
    Rigidbody2D myRigidBody;

    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        moveSpeed = moveSpeed + Random.Range(slowestSpeed, fastestSpeed);
    }
    
    void Update () {
        MoveHorizontally();        
    }

    private void MoveHorizontally()
    {
        if (facingRight == true)
        {
            Vector2 enemyVelocity = new Vector2(moveSpeed, 0f);
            myRigidBody.velocity = enemyVelocity;
        }
        else
        {
            Vector2 enemyVelocity = new Vector2(-moveSpeed, 0f);
            myRigidBody.velocity = enemyVelocity;
        }
    } 

    void OnTriggerExit2D(Collider2D other)
    {
        facingRight = !facingRight;
        transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
    }
}
