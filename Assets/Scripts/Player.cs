using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpSpeed = 5f; // todo consider Vector2

    Rigidbody2D playerRigidBody;
    public float fudgeFactor = 0.1f;

    // Use this for initialization
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessHorizontal();
        ProcessJumps();
        FaceCorrectDirection();
    }

    private void FaceCorrectDirection()
    {
        print(playerRigidBody.velocity.x);   
        if (playerRigidBody.velocity.x > fudgeFactor)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (playerRigidBody.velocity.x < -fudgeFactor) // note -
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
    }

    private void ProcessHorizontal()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value between -1 and +1

        float existingVerticalSpeed = playerRigidBody.velocity.y;
        Vector2 playerVelocity = new Vector2(controlThrow * speed, existingVerticalSpeed);
        playerRigidBody.velocity = playerVelocity;
    }

    private void ProcessJumps()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump")) // Down so once per press
        {
            Vector2 jumpVelocityAdded = new Vector2(0f, jumpSpeed);
            playerRigidBody.velocity += jumpVelocityAdded;
        }
    }
}
