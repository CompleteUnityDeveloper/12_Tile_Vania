using System.Collections;
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

    void Start()
    {
        livesText.text = playerLives.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameProgress();
        }
    }

    void TakeLife()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        playerLives--;
        livesText.text = playerLives.ToString();
    }

    void ResetGameProgress()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject); // todo actually instantiate the GameSession somewhere
    }
}
