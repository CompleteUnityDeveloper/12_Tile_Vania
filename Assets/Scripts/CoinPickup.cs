using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    int pointsForCoinPickup = 100;
    [SerializeField] AudioClip coinPickupSound;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (!other.GetComponent<PlayerMovement>())
            return;
        else
        {
            FindObjectOfType<ScoreBoard>().AddPoints(pointsForCoinPickup);
            GetComponent<AudioSource>().PlayOneShot(coinPickupSound);
            print("should be playing coin sound now");
        }
        Destroy(gameObject);       
    }

}
