using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

    public GameObject player;
    

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        //gameObject.transform.parent = player.transform;
        if (PlayerPrefs.GetInt("Player") == 4)
            gameObject.transform.position = new Vector3(player.transform.position.x + 0.1f, player.transform.position.y - 0.2f, 0);
        else if(PlayerPrefs.GetInt("Player") == 3)
            gameObject.transform.position = new Vector3(player.transform.position.x - 0.4f, player.transform.position.y - 0.4f, 0);
        else if(PlayerPrefs.GetInt("Player") == 2)
            gameObject.transform.position = new Vector3(player.transform.position.x - 0.4f, player.transform.position.y - 0.15f, 0);
        else if(PlayerPrefs.GetInt("Player") == 1)
            gameObject.transform.position = new Vector3(player.transform.position.x - 0.1f, player.transform.position.y, 0);
        else
            gameObject.transform.position = new Vector3(player.transform.position.x + 0.1f, player.transform.position.y + 0.2f, 0);
    }
	
	// Update is called once per frame
	void Update () {
        //transform.position = player.transform.position;
	}

    private void FixedUpdate() {
        if (PlayerPrefs.GetInt("Player") == 4)
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.15f, 0);
        else if (PlayerPrefs.GetInt("Player") == 3)
            gameObject.transform.position = new Vector3(player.transform.position.x - 0.4f, player.transform.position.y - 0.4f, 0);
        else if (PlayerPrefs.GetInt("Player") == 2)
            gameObject.transform.position = new Vector3(player.transform.position.x - 0.4f, player.transform.position.y - 0.15f, 0);
        else if (PlayerPrefs.GetInt("Player") == 1)
            gameObject.transform.position = new Vector3(player.transform.position.x - 0.1f, player.transform.position.y, 0);
        else
            gameObject.transform.position = new Vector3(player.transform.position.x + 0.1f, player.transform.position.y + 0.2f, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Enemy") {

            BubbleCollect.bubbleHappen = false;

            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
