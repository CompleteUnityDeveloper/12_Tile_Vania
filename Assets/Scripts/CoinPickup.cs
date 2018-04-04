using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// todo Rick ensure prefabs are up-to date by creating another scene
// todo we need another lifecycle or two, intra / inter level yadda
public class CoinPickup : MonoBehaviour
{
    [SerializeField] int pointsForCoinPickup = 100;
    [SerializeField] AudioClip coinPickupSound;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (!other.GetComponent<PlayerMovement>()) { return; }

        FindObjectOfType<ScoreBoard>().AddPoints(pointsForCoinPickup);
        GetComponent<AudioSource>().PlayOneShot(coinPickupSound);
        Destroy(gameObject);       
    }
}