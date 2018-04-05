using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterDetector : MonoBehaviour {

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
}
