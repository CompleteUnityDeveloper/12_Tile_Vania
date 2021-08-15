using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    [SerializeField] AudioClip coinPickUpSFX;

    [SerializeField] int pointsForCoinPickup = 100;

    // Speech Bubble that shows when picking up object
    [SerializeField]
    Sprite speechBubble = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (gameObject.name == "Shungite")
        {

            Debug.Log("Picked up Shungite!");

            FindObjectOfType<GameSession>().AddLife();

            FindObjectOfType<SpeechBubble>().ChangeBubble(speechBubble);

        }
        else
        {
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);

        }

        if (coinPickUpSFX)
        {
            AudioSource.PlayClipAtPoint(coinPickUpSFX, transform.position);
        }


        Destroy(gameObject);

    }
}
