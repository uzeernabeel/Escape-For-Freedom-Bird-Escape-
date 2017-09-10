using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigPowerOpposite : MonoBehaviour {

    public static bool smallPowerHappen;

    public GameObject g;


    private void Awake() {
        g = GameObject.FindWithTag("Player");
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Player") {

            g.transform.localScale -= new Vector3(.3f, .3f, 0);


            smallPowerHappen = true;

            if (Social.localUser.authenticated)
                PlayGamesScript.IncrementAchievement(GPGSIds.achievement_small_power, 2);

            //Bird.upForce = 35f;

            //box2d.isTrigger = true;

            GameControl.instance.timeElapsed += 10;
            GameControl.instance.coinCollect = true;
            GameControl.instance.timeRemaining = 3f;

            gameObject.SetActive(false);
        }
    }


}
