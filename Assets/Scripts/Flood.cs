using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flood : MonoBehaviour
{
    [SerializeField] float floodRate = 0.2f;
	
	// Update is called once per frame
	void Update ()
    {
        float yMove = floodRate * Time.deltaTime;
        transform.Translate(new Vector2(0f, yMove));
	}
}
