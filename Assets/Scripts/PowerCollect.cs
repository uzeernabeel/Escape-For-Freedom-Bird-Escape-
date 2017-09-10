using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCollect : MonoBehaviour {

    public static bool done;
    public GameObject g;
    public PolygonCollider2D box2d;
    public Rigidbody2D rb2d;
    public static float ScrollingSpeedNow;
    public float timeRemaining = 2f;

    // Use this for initialization
    void Start() {
        g = GameObject.FindGameObjectWithTag("Player");
        box2d = g.GetComponent<PolygonCollider2D>();
        rb2d = g.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
       /* if (done)
            timeRemaining -= Time.deltaTime;

        if (timeRemaining < 0) { 
            box2d.isTrigger = false;
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            ScrollingObject.scrollSpeed = ScrollingSpeedNow;
        } */
    }

    /*private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.GetComponent<Bird>()) {

            GameControl.instance.timeElapsed += 10;
            GameControl.instance.coinCollect = true;
            GameControl.instance.timeRemaining = 3f;

            ScrollingSpeedNow = ScrollingObject.scrollSpeed;

            ScrollingObject.scrollSpeed = -40f;

            done = true;

            box2d.isTrigger = true;
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;

            gameObject.SetActive(false);

        }*/

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.tag == "Player") { 

                GameControl.instance.timeElapsed += 25;
                //GameControl.instance.coinCollect = true;
                GameControl.instance.timeRemaining = 3f;

                ScrollingSpeedNow = ScrollingObject.scrollSpeed;

                ScrollingObject.scrollSpeed = -40f;

                if (Social.localUser.authenticated)
                    PlayGamesScript.IncrementAchievement(GPGSIds.achievement_speed_power, 2);

                done = true;

                box2d.isTrigger = true;
                rb2d.constraints = RigidbodyConstraints2D.FreezeAll;

                gameObject.SetActive(false);

            }
        }
}