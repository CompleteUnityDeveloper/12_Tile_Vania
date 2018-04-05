using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    [SerializeField] float respawnLoadDelay = 2f;
    [SerializeField] Vector2 deathKick = new Vector2(25f, 25f);

    [SerializeField] bool isAlive = true;

    Rigidbody2D myRigidBody;

    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        GetComponent<PlayerMovement>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isAlive &&
            other.gameObject.GetComponent<VerticalScroll>() ||
            other.gameObject.GetComponent<EnemyMovement>())
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        isAlive = false;
        myRigidBody.velocity = deathKick;
        FindObjectOfType<SFX>().PlayDeathSound();
        StartCoroutine(RunDramaticDeathSequence());
        //reduce lives etc
        //stop playing being able to control movement

    }

    private IEnumerator RunDramaticDeathSequence()
    {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<Animator>().SetBool("Dying", true);
        //myRigidBody.freezeRotation = true;
        //myRigidBody.velocity = deathKick;

        yield return new WaitForSecondsRealtime(respawnLoadDelay);
        isAlive = true;
    }



}
