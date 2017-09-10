using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!BigPower.bigPowerHappen) {
            if (collision.gameObject.tag == "Player") {
                GameControl.instance.BirdDied();
            }
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.GetComponent<Bird>() != null) {
            GameControl.instance.BirdDied();
        }
    }*/

}
