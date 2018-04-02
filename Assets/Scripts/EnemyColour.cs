using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColour : MonoBehaviour {

    SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        Color newColor = new Color(Random.Range(0f, 1f), Random.Range(0.5f,1f), Random.Range(0.5f, 1f));
        GetComponent<SpriteRenderer>().color = newColor;
	}	
}
