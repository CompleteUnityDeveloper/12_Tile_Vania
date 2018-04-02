using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour {

    [SerializeField] int startingLives = 3;
    int currentLives;

	// Use this for initialization
	void Start () {
        currentLives = startingLives;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeLife()
    {
        currentLives--;
        print(currentLives);
    }


}
