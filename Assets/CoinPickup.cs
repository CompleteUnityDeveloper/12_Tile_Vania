using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    int pointsForCoinPickup = 100;
 
    void OnTriggerEnter2D (Collider2D other)
    {
        if (!other.GetComponent<PlayerMovement>())
            return;
        else
        {
            ScoreBoard.AddPoints(pointsForCoinPickup);
            FindObjectOfType<SFX>().PlayCoinSound();
        }
        Destroy(gameObject);       
    }

}
