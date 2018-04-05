using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void StartFirstLevel()
    {
        SceneManager.LoadScene(1);
        // todo instantiate Game Session
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

