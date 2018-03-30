using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float moveSpeed = .5f;

    Rigidbody2D myRigidBody;
    
    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
