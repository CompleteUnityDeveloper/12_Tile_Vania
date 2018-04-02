using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour {

    [SerializeField] int startingLives = 3;
    int currentLives;
    static bool created = false;
    Text livesText;

    // Note: Might need a different strategy with this as we need a way to store data across scenes
    // (eg. Lives, coins, kills, etc). Currently they are reset.

    void Start()
    {
        currentLives = startingLives;
        livesText = GetComponent<Text>();
        livesText.text = currentLives.ToString();
    }

     public void ProcessTheAfterLife()
    {
        if(currentLives > 0)
        {
            SceneManager.LoadScene(SceneManager.sceneCount);  // TODO: need to stop the level load from reseting lives back to starting value
            TakeLife();
        }
        else
        {
            return; // TODO: will need a game over screen
        }
    }

    public void TakeLife()
    {
        currentLives--;
        livesText.text = currentLives.ToString();
    }
}
