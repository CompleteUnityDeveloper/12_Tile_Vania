using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float slowestSpeed = 0.5f;
    [SerializeField] float fastestSpeed = 2f;
    
    enum SpriteFacing { left, right };
    [SerializeField] SpriteFacing startFacingDirection;

    float moveSpeed;
    Rigidbody2D myRigidBody;
    
    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(slowestSpeed, fastestSpeed);
    }
    
    void Update ()
    {
        if (GetFacingDirection() == SpriteFacing.right) 
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }       
    }

    SpriteFacing GetFacingDirection()
    {
        if (startFacingDirection == SpriteFacing.right && transform.localScale.x > 0)
        {
            return SpriteFacing.right;
        }
        else if (startFacingDirection == SpriteFacing.left && transform.localScale.x < 0)
        {
            return SpriteFacing.right;
        }
        else
        {
            return SpriteFacing.left;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Flip sprite
        transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
    }
}
