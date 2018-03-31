using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float moveSpeed = .01f;

    bool facingRight = false;

    Rigidbody2D myRigidBody;
    

    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
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
        print("No longer in contact with " + other.transform.name);
        facingRight = !facingRight;
        transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
    }

}
