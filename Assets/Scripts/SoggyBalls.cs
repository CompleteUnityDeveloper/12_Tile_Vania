using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoggyBalls : MonoBehaviour {

    [SerializeField] string waterLayerName;
 
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();

        if (!GameObject.Find(waterLayerName))
        {
            Debug.LogWarning("Named water layer not found");
        }
    }
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == waterLayerName)
        {
            playerMovement.ballsAreWet = true;
        }
    }
}
