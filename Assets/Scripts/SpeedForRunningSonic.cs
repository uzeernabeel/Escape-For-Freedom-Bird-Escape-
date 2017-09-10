using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedForRunningSonic : MonoBehaviour {

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb2d.velocity = new Vector2(Mathf.Abs(ScrollingObject.scrollSpeed) - 3, 0);
	}

    private void Update() { 

        if (transform.position.x > 0)
            gameObject.SetActive(false);
    }

    private void OnBecameInvisible() {
        gameObject.SetActive(false);
    }
}
