using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    int score; 

    Text scoreBoardText;

    void Awake()
    {
        int numScoreBoards = FindObjectsOfType<ScoreBoard>().Length;
        if (numScoreBoards > 1)
        {
            print("Asked to destroy myself:" + gameObject);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            print("Asked not to destroy myself:" + gameObject);

        }
    }

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
