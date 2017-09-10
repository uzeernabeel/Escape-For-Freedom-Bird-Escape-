using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCollect : MonoBehaviour {

    public static bool RocketTime;

    //private Rigidbody2D rb2d;

    public GameObject rocketObject;         //This is a reference to the rocket in front of bird
    public GameObject rocketObject2;
    public GameObject rocketObject3;
    public GameObject bird;


    Vector2 position = new Vector2(-15f, 0);
    Vector2 position2 = new Vector2(-15f, 3f);
    Vector2 position3 = new Vector2(-15f, -3f);

    private void Awake() {

        //rocketObject = GameObject.FindWithTag("Rocket");
        //rocketObject2 = GameObject.FindWithTag("Rocket");
        //rocketObject3 = GameObject.FindWithTag("Rocket");

        bird = GameObject.FindGameObjectWithTag("Player");
        //all = GameObject.FindGameObjectWithTag("bullet");
        //rocketObject = GetComponent<Rocket>().gameObject;
    }

    // Use this for initialization
    void Start () {
        //rb2d = GetComponent<Rigidbody2D>();
        rocketObject = (GameObject)Instantiate(Resources.Load("rocket"), new Vector3(-25, -12, 0), Quaternion.identity);
        rocketObject2 = (GameObject)Instantiate(Resources.Load("rocket"), new Vector3(-24.5f, -12, 0), Quaternion.identity);
        rocketObject3 = (GameObject)Instantiate(Resources.Load("rocket"), new Vector3(-25, -12, 0), Quaternion.identity);

    }

    // Update is called once per frame
    /*void Update () {

       if (GameControl.instance.gameOver) {
           gameObject.SetActive(false);
       }

      if (ha) {
           rb2d.velocity = new Vector2(Mathf.Abs(ScrollingObject.scrollSpeed) - 3, 0);
       } else {
           rb2d.velocity = new Vector2(ScrollingObject.scrollSpeed, 0);
       }

       if (rb2d.transform.position.x > 30) {
           gameObject.SetActive(false);
           //gameObject.transform.localScale -= new Vector3(.2f, .2f, 0);
           ha = false;
       } */

//}

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Player") {
            //Debug.Log("Player collided with rocket");
            
            //Show rocket on screen
            rocketObject.SetActive(true);
            rocketObject2.SetActive(true);
            rocketObject3.SetActive(true);

            if (Social.localUser.authenticated)
                PlayGamesScript.IncrementAchievement(GPGSIds.achievement_rocket_power, 1);

            //change their position to 0
            rocketObject.transform.position = position;
            rocketObject2.transform.position = position2;
            rocketObject3.transform.position = position3;


            gameObject.SetActive(false);
        }

    }
}
