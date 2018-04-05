using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    [SerializeField] float respawnLoadDelay = 2f;

    Rigidbody2D myRigidBody;

    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        GetComponent<PlayerMovement>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<VerticalScroll>() ||
            other.gameObject.GetComponent<EnemyMovement>())
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
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
        FindObjectOfType<LifeCounter>().ProcessTheAfterLife();
    }

}
