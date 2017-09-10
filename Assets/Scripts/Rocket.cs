using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb2d.velocity = new Vector2(Mathf.Abs(ScrollingObject.scrollSpeed) - 3, 0);

        if (transform.position.x > 0) {
            gameObject.SetActive(false);
        }


    }

    /*private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
