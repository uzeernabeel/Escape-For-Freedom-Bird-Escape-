using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantVelocity : MonoBehaviour {

    public Vector2 velocity = Vector2.zero;

    private Rigidbody2D body2d;

	// Use this for initialization
	void Start () {
        body2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        body2d.velocity = velocity;
	}
}
