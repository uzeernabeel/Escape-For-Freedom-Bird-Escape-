using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private float groundHorizontalLength;
    private BoxCollider2D groundCollider;

	// Use this for initialization
	void Start () {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(transform.position.x < -groundHorizontalLength - 25) {
            RepositionBackground();
        }

	}

    private void RepositionBackground() {
        Vector2 groundOffset = new Vector2((groundHorizontalLength * 8f) -.75f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
