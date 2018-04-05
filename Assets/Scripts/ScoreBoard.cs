using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    int score; 
    Text scoreBoardText;

    void Start()
    {
        scoreBoardText = GetComponent<Text>();
        scoreBoardText.text = score.ToString();
    }

    void Update()
    {
        scoreBoardText.text = score.ToString();    
    }

    public void AddPoints (int pointsToAdd)
    {
        score += pointsToAdd;
    }
}
