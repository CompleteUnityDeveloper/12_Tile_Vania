using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameProgress : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] Text livesText;

    // TODO add score in here also

    // singleton - ensures that this gameObject and all children are not destroyed
    // until game is reset
    //void Awake()
    //{
    //    int numGameProgresses = FindObjectsOfType<GameProgress>().Length;
    //    if (numGameProgresses > 1)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        DontDestroyOnLoad(gameObject);
    //    }
    //}

    private void Start()
    {
        livesText = GetComponent<Text>();
        livesText.text = playerLives.ToString();
        print(playerLives);
    }


    public void ProcessTheAfterLife()
    {
        if (playerLives > 1)
        {
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
            TakeLife();
        }
        else
        {
            // TODO: will need a game over screen
            SceneManager.LoadScene(0);
            ResetGameProgress();
        }
    }

    public void TakeLife()
    {
        playerLives--;
        livesText.text = playerLives.ToString();
    }

    public void ResetGameProgress()
    {
        Destroy(gameObject);
    }
}
