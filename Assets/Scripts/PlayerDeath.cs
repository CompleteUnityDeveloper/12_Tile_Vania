using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    [SerializeField] float respawnLoadDelay = 2f;
    [SerializeField] Vector2 deathKick = new Vector2(25f, 25f);

    bool isAlive = true;

    Rigidbody2D myRigidBody;

    // Use this for initialization
    void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        GetComponent<PlayerMovement>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isAlive) { return; }

        if (other.gameObject.GetComponent<VerticalScroll>() ||
            other.gameObject.GetComponent<EnemyMovement>())
        {
            StartCoroutine(RunDramaticDeathSequence());
        }
    }

    private IEnumerator RunDramaticDeathSequence()
    {
        isAlive = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<Animator>().SetBool("Dying", true);

        yield return new WaitForSecondsRealtime(respawnLoadDelay);
        FindObjectOfType<GameProgress>().ProcessTheAfterLife();
        myRigidBody.velocity = deathKick;
        FindObjectOfType<SFX>().PlayDeathSound();
    }



}
