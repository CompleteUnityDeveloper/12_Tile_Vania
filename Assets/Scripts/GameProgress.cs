using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour {

    // player lives
    // player score
    // dont destroy on load
    // handle scene loading
    // singleton to ensure we dont have multiple
    // remember the level we are on - scene manager


    void Awake()
    {
        int numGameProgresses = FindObjectsOfType<GameProgress>().Length;
        if (numGameProgresses > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetGameProgress()
    {
        Destroy(gameObject);
    }

}
