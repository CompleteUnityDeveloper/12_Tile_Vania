using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{

    // Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] AudioClip[] jumpSounds;

    // State
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    AudioSource myAudioSource;
    Collider2D myCollider;

    // todo remove all 4 caches
    public bool isNearLadder = false;  // available to ladder collision component
    public bool isOnFloor = false;
    float gravityScaleAtStart;

    // Messages then public methods
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        gravityScaleAtStart = myRigidBody.gravityScale; // can't change value at runtime because placed in Start
        myAudioSource = GetComponent<AudioSource>();
        myCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        VerticalMovement();
        HorizontalMovement();
        var layerMask = LayerMask.GetMask("Ladder"); // could be more than one
        print(myCollider.IsTouchingLayers(layerMask));
    }

    void LateUpdate() // Use for updating view
    {
        FlipSprite(); // Here so movement has settled
    }

    private void VerticalMovement()
    {
        if (isNearLadder)
        {
            ClimbLadder();
        }
        else
        {
            Jump();
        }
    }
    
    private void ClimbLadder()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);  
        myRigidBody.velocity = climbVelocity;

        bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon; 
        myAnimator.SetBool("Climbing", playerHasVerticalSpeed);
    }

    private void Jump()
    {

        if (!isOnFloor) { return; }

        if (CrossPlatformInputManager.GetButtonDown("Jump")) // Down so once per press
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
            var clip = jumpSounds[UnityEngine.Random.Range(0, jumpSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
        myAnimator.SetBool("Climbing", false);
    }
        
    private void HorizontalMovement()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value between -1 and +1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);  
     }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            // reverse x scale to flip player horizontally
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }
}
