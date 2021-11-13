using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    // Config
    [SerializeField] AudioClip hazardSound;
    [SerializeField] AudioClip[] damageSound;
    [SerializeField] float runSpeed = 5f;
    float initialRunSpeed = 0f;
    [SerializeField] float jumpSpeed = 5f;
    float initialJumpSpeed = 0f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(25f, 25f);

    // [SerializeField] List<Sprite> damageSpeeches = new List<Sprite>();


    // State
    bool isAlive = true;

    // Cached component references
    Rigidbody2D myRigidBody;
    SpriteRenderer mySprite;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeet;
    float gravityScaleAtStart;

    // Message then methods
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;

        getSpeedValues();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }

        Run();
        ClimbLadder();
        Jump();
        HitWall();
        FlipSprite();
        LooseHealth();
        Sick();
    }

    private void getSpeedValues()
    {
        initialRunSpeed = runSpeed;
        initialJumpSpeed = jumpSpeed;
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value is betweeen -1 to +1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
    }

    private void HitWall()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Wall")))
        {
            Debug.Log("Hit wall.");
            return;
        }

    }

    private void ClimbLadder()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myAnimator.SetBool("Climbing", false);
            myRigidBody.gravityScale = gravityScaleAtStart;
            return;
        }

        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);
        myRigidBody.velocity = climbVelocity;
        myRigidBody.gravityScale = 0f;

        bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("Climbing", playerHasVerticalSpeed);

    }

    private void Jump()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }

    private void LooseHealth()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            StartCoroutine("Dying");
            // mySprite.enabled = false;
            GetComponent<Rigidbody2D>().velocity = deathKick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();

            // Show a random damage Speech Bubble when taking damage
            // DamageSpeechBubble();

            // If there's an Audio Clip in the first array position play the damage sound
            if (damageSound[0])
            {
                // Assign a random Audio Clip
                int rand = Random.Range(0, damageSound.Length);

                AudioSource.PlayClipAtPoint(damageSound[rand], transform.position);
            }
        }

    }

    // private void DamageSpeechBubble()
    // {
    //     // Choose a random Damage Speech Bubble
    //     Sprite randomSpeech = damageSpeeches[Random.Range(0, damageSpeeches.Count)];

    //     // Call Speech Bubble method
    //     FindObjectOfType<SpeechBubble>().ChangeBubble(randomSpeech);
    // }

    private void Sick()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("5G")))
        {
            GetComponent<SpriteRenderer>().color = Color.green;

            runSpeed = (initialRunSpeed / 2);
            jumpSpeed = (initialJumpSpeed / 2);

            AudioSource.PlayClipAtPoint(hazardSound, transform.position, 0.1f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            runSpeed = initialRunSpeed;
            jumpSpeed = initialJumpSpeed;
        }
    }

    IEnumerator Dying()
    {
        myAnimator.SetTrigger("Dying");
        yield return new WaitForSeconds(0.6f);
        isAlive = true;
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }

        // Flip speech bubble if player is facing left so text is legible
        if (transform.localScale.x == -1)
        {
            FindObjectOfType<SpeechBubble>().FlipSprite();
        }
        else
        {
            FindObjectOfType<SpeechBubble>().DefaultSprite();
        }

    }

}
