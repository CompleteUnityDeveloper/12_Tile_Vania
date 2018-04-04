using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// todo genericise this and flood detector as nearly identical
public class LadderDetector : MonoBehaviour
{
    [SerializeField] string climbLayerName;

    PlayerMovement playerMovement;
    
    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        if (!GameObject.Find(climbLayerName))
        {
            Debug.LogWarning("Named climb layer not found"); // todo genericise
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == climbLayerName)
        {
            playerMovement.isNearLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == climbLayerName) 
        {
            playerMovement.isNearLadder = false;
        }
    }
}
