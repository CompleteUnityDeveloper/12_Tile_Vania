using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// todo Rick ensure prefabs are up-to date by creating another scene
// todo we need another lifecycle or two, intra / inter level yadda
public class CoinPickup : MonoBehaviour
{
    [SerializeField] int pointsForCoinPickup = 100;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (!other.GetComponent<Player>()) { return; }

        FindObjectOfType<ScoreBoard>().AddPoints(pointsForCoinPickup);
        FindObjectOfType<SFX>().PlayCoinSound();
        Destroy(gameObject);       
    }
}