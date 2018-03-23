using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

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
