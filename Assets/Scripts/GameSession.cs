﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] Text livesText;

    // TODO add score in here also

    // singleton - ensures that this gameObject and all children are not destroyed
    // until game is reset
    void Awake()
    {
        int numGameProgresses = FindObjectsOfType<GameSession>().Length;
        if (numGameProgresses > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        livesText.text = playerLives.ToString();
    }

    public void ResetGameProgress()
    {
        Destroy(gameObject);
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            // TODO: will need a game over screen
            SceneManager.LoadScene(0);
            ResetGameProgress();
        }
    }

    void TakeLife()
    {
        SceneManager.LoadScene(0);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        playerLives--;
        livesText.text = playerLives.ToString();
    }
}