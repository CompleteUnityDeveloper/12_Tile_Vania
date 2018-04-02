using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteStartColorRandomiser : MonoBehaviour {

    [SerializeField] float lowestRValue = 0f;
    [SerializeField] float lowestGValue = 0.5f;
    [SerializeField] float lowestBValue = 0.5f;                              

    SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start ()
    {
        Color newColor = new Color(
            Random.Range(lowestRValue, 1f),
            Random.Range(lowestGValue,1f),
            Random.Range(lowestBValue, 1f)
        );

        GetComponent<SpriteRenderer>().color = newColor;
	}	
}
