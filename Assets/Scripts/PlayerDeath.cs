using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    [SerializeField] float respawnLoadDelay = 2f;
    [SerializeField] Vector2 deathKick = new Vector2(25f, 25f);

    [SerializeField] LevelExit levelexit;

    [Header("Required Wiring")]
    [SerializeField] GameSession gameSession;

    public bool isAlive = true; // TODO Make private

    Rigidbody2D myRigidBody;

    // Use this for initialization
    void Start ()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        GetComponent<PlayerMovement>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.name);
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
        myRigidBody.velocity = deathKick;
        FindObjectOfType<SFX>().PlayDeathSound();

        yield return new WaitForSecondsRealtime(respawnLoadDelay);
        gameSession.ProcessPlayerDeath();

    }



}
