using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    [SerializeField] Text livesText;

    int currentLives = 3;
    //Text livesText;

    void Start()
    {
        //livesText = GetComponent<Text>();
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
            SceneManager.LoadScene(0);
            FindObjectOfType<GameProgress>().ResetGameProgress();
            // TODO: will need a game over screen
        }
    }

    public void TakeLife()
    {
        currentLives--;
        livesText.text = currentLives.ToString();
    }
}
