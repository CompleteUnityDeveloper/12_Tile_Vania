using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(gameObject.name);
    }

}
