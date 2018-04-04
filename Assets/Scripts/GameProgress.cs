using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
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
