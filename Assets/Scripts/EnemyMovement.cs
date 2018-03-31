using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// note this is doing more than enemy movement
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float slowestSpeed = 0.5f;
    [SerializeField] float fastestSpeed = 2f;
    [SerializeField] string climbLayerName;

    private void Start()
    {
        if (!GameObject.Find(climbLayerName))
        {
            Debug.LogWarning("Named climb layer not found"); // todo genericise
        }
        myRigidBody = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        moveSpeed = Random.Range(slowestSpeed, fastestSpeed);
    }

    float moveSpeed;

    Rigidbody2D myRigidBody;
    PlayerMovement playerMovement;
    
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
        // Flip the enemy sprite in x
        if (other.gameObject.name != climbLayerName)
        {
            ReverseDiretion();
        }
    }

    void ReverseDiretion()
    {
        transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // safer to find by type than a string-referenced name
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            playerMovement.collidedWithEnemy = true;
        }
    }
}
