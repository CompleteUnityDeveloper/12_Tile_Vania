using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// todo note this is VERY similar to LadderDetector so far
public class FloorDetector : MonoBehaviour
{
    [SerializeField] string floorLayerName;

    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        if (!GameObject.Find(floorLayerName))
        {
            Debug.LogWarning("Named floor layer not in scene");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == floorLayerName)
        {
            playerMovement.isOnFloor = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == floorLayerName)
        {
            playerMovement.isOnFloor = false;
        }
    }   
}
