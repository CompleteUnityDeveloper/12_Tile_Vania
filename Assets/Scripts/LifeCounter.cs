using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    int currentLives = 3;
    Text livesText;

    void Start()
    {
        livesText = GetComponent<Text>();
        livesText.text = currentLives.ToString();
    }

    public void ProcessTheAfterLife()
    {
        if (currentLives > 0)
        {
            SceneManager.LoadScene(SceneManager.sceneCount);
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
