using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    [SerializeField] int pointsForCoinPickup = 100;
    [SerializeField] AudioClip coinPickupSound;
    AudioSource myAudioSource;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (!other.GetComponent<PlayerMovement>())
            return;
        else
        {
            ScoreBoard.AddPoints(pointsForCoinPickup);
        }
        Destroy(gameObject);       
    }

}
