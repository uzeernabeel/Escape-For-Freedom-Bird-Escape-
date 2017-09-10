using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingObject : MonoBehaviour {

    public static float scrollSpeed = -7f; 
    private Rigidbody2D rb2d;

    public static float time = 0;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    private void FixedUpdate() {
        
        rb2d.velocity = new Vector2(scrollSpeed, 0);

        if (GameControl.instance.gameOver)
            rb2d.velocity = Vector2.zero;
    }

    void Update() {

        if (PowerCollect.done == false) {
            if (GameControl.instance.timeElapsed > 4500) {
                scrollSpeed = -20f;
            } else if (GameControl.instance.timeElapsed > 4000) {
                scrollSpeed = -15f;
            } else if (GameControl.instance.timeElapsed > 3100) {
                scrollSpeed = -13f;
            } else if (GameControl.instance.timeElapsed > 1500) {
                scrollSpeed = -11f;
            } else if (GameControl.instance.timeElapsed > 700) {
                scrollSpeed = -9f;
            } else if (GameControl.instance.timeElapsed > 300) {
                scrollSpeed = -8f;
            } else
                scrollSpeed = -7f;

            }
        }
}
