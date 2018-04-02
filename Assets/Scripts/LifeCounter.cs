using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour {

    [SerializeField] int playerLives = 3;

    Text livesText;

    void Start()
    {
        livesText = GetComponent<Text>();
        livesText.text = playerLives.ToString();
    }

    public void TakeLife()
    {
        playerLives--;
        livesText.text = playerLives.ToString();
    }
}
