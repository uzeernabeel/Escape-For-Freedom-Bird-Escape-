using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigPower : MonoBehaviour {

    public static bool bigPowerHappen;

    public GameObject g;

    private int BigPowerNumber;

    
    private void Awake() {
        g = GameObject.FindWithTag("Player");
    }

    // Use this for initialization
    void Start () {
  
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Player") {

            g.transform.localScale += new Vector3(2.5f, 2.5f, 0);

            bigPowerHappen = true;

            if (Social.localUser.authenticated)
                PlayGamesScript.IncrementAchievement(GPGSIds.achievement_big_power, 1);

            //Bird.upForce = 35f;

            //box2d.isTrigger = true;

            GameControl.instance.timeElapsed += 10;
            GameControl.instance.coinCollect = true;
            //GameControl.instance.timeRemaining = 3f;

            gameObject.SetActive(false);
        }
    }

    
}
