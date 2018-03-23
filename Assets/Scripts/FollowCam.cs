using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    Player player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector2 newCamPos = new Vector2(player.transform.position.x, player.transform.position.y);
        transform.position = new Vector3(newCamPos.x, newCamPos.y, transform.position.z);
	}
}
