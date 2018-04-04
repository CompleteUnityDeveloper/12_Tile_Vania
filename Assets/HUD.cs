using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

    void Awake()
    {
        int numHUDs = FindObjectsOfType<HUD>().Length;
        if (numHUDs > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
