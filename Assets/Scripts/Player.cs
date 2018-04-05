using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    // Config
    [Header("How To Live")]
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] AudioClip[] jumpSounds;
    [Header("How To Die")]
    [SerializeField] float respawnLoadDelay = 2f; // todo move elsewhere
    [SerializeField] Vector2 deathKick = new Vector2(25f, 25f);

    // State
    bool isAlive = true;

    // Cached component references
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    AudioSource myAudioSource;
    Collider2D myCollider;

    // Messages then public methods
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
        myCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (!isAlive) { return;  }

        Run();
        Jump();
        ClimbLadder();
        Die();
    }

    void LateUpdate() // Use for updating view
    {
        FlipSprite(); // Here so movement has settled
    }
    
    private void ClimbLadder()
    {
        if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Ladder"))) { return; }

        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);
        myRigidBody.velocity = climbVelocity;

        bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("Climbing", playerHasVerticalSpeed);
    }

    void Jump()
    {
        if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if (CrossPlatformInputManager.GetButtonDown("Jump")) // Down so once per press
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
            var clip = jumpSounds[UnityEngine.Random.Range(0, jumpSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
        myAnimator.SetBool("Climbing", false);
    }
        
    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value between -1 and +1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);  
     }

    void Die()
    {
        if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Water", "Enemy")))
        { 
            return;
        }
        else
        {
            StartCoroutine(RunDramaticDeathSequence());
        }
    }

    IEnumerator RunDramaticDeathSequence()
    {
        isAlive = false;
        GetComponent<Player>().enabled = false;
        GetComponent<Animator>().SetBool("Dying", true);
        GetComponent<Rigidbody2D>().velocity = deathKick;
        FindObjectOfType<SFX>().PlayDeathSound();
        yield return new WaitForSeconds(respawnLoadDelay);
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            // reverse x scale to flip player horizontally
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }
}
