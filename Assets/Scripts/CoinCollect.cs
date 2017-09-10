using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour {

    public static bool isTriggeredForSonic;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

        

        /*if (transform.position.x < -Screen.width)
            gameObject.SetActive(true);
            renderer.enabled = true;

        if (rb2d.position.x > Screen.width && renderer.enabled == false)
            renderer.enabled = true;*/
	}

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Player") { 

            //renderer.enabled = false;
            if (isTriggeredForSonic == false)
                isTriggeredForSonic = true;
            
            //enabled = false;
            GameControl.instance.timeElapsed += 10;
            GameControl.instance.coins += 1;
            GameControl.instance.coinCollect = true;
            GameControl.instance.timeRemaining = 3f;

            //source.Play();

            gameObject.SetActive(false);

        }

    }
}
