using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] Scene mainMenu;

	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Resume();
    }

    public void QuitToMainMenu()
    {
        print("quitting game");
    }
 
}
