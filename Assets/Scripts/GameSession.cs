using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = 3;

    int maxLives = 0;
    [SerializeField] int score = 0;

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;

    // Setting UI Canvas as the Parent for the hearts
    [SerializeField] GameObject heartParent;

    // Adding the heart prefab image
    [SerializeField] Image heartPrefab;

    // Adding the heart sprite
    [SerializeField] Sprite heartSprite;

    // Creating a list of heart images
    List<Image> hearts = new List<Image>();

    // x value of heart
    int heartx = 50;




    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
        maxLives = playerLives;

        // Create hearts
        for (int i = 0; i < playerLives; i++)
        {
            // Add a heart image prefab on to the list
            hearts.Add(heartPrefab);

            // Assign a heart list item to a new object
            Image heart = Instantiate(hearts[i]);

            // Put the new image object under the heartParant aka UI Canvas
            heart.rectTransform.SetParent(heartParent.transform, true);

            // Set the position of the new object to the top left
            heart.rectTransform.anchoredPosition = new Vector2(heartx, -50);

            // Change the heartx value so the next heart is shifted to the right
            heartx += 40;

        }

        Debug.Log("Hearts: " + hearts.Count);

    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();

        // Add life when you have enough rolls but no more than what the Max is
        if (score % 100 == 0 && playerLives < maxLives)
        {
            AddLife();

            Debug.Log("Added life");
        }
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        playerLives--;
        // var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();

        // Remove last item in heart list
        hearts.RemoveAt(hearts.Count - 1);

        // Remove one of the hearts
        DestroyWithTag("Heart");

        Debug.Log("Hearts: " + hearts.Count);

        // Change the heartx value so the next heart is shifted to the right
        heartx -= 40;
    }

    public void AddLife()
    {
        playerLives++;
        maxLives++;

        livesText.text = playerLives.ToString();

        // Add heart item to list
        hearts.Add(heartPrefab);

        // Assign a heart list item to a new object
        Image heart = Instantiate(hearts[hearts.Count - 1]);

        // Put the new image object under the heartParant aka UI Canvas
        heart.rectTransform.SetParent(heartParent.transform, true);

        // Set the position of the new object to the top left
        heart.rectTransform.anchoredPosition = new Vector2(heartx, -50);

        // Change the heartx value so the next heart is shifted to the right
        heartx += 40;

        Debug.Log("Hearts: " + hearts.Count);
    }

    private void DestroyWithTag(string destroyTag)
    {
        // Create a new array
        GameObject[] destroyObject;

        // Add all objects with specified tag to array
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);

        // Remove last heart in array
        Destroy(destroyObject[hearts.Count]);

    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
