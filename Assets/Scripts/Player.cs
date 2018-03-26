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
        bool playerIsNotMoving = Mathf.Abs(playerRigidBody.velocity.x) < Mathf.Epsilon;
        if (playerIsNotMoving)
        {
            // don't change player direction
        }
        else
        {
            // reverse x scale to flip player horizontally
            transform.localScale = new Vector2(Mathf.Sign(playerRigidBody.velocity.x), 1f);  
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
