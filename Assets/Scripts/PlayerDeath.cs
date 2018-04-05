using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    [SerializeField] float respawnLoadDelay = 2f;
    [SerializeField] Vector2 deathKick = new Vector2(25f, 25f);

    bool isAlive = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isAlive) { return; }

        if (other.gameObject.GetComponent<VerticalScroll>() ||
            other.gameObject.GetComponent<EnemyMovement>())
        {
            StartCoroutine(StartDramaticDeathSequence());
        }
    }

    IEnumerator StartDramaticDeathSequence()
    {
        isAlive = false;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<Animator>().SetBool("Dying", true);
        GetComponent<Rigidbody2D>().velocity = deathKick;
        FindObjectOfType<SFX>().PlayDeathSound();
        yield return new WaitForSeconds(respawnLoadDelay);
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }
}
