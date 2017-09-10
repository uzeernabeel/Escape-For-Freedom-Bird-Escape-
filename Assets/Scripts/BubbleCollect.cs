using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCollect : MonoBehaviour {

    public GameObject bubble;
    [SerializeField]
    public static bool bubbleHappen;

    private void Awake() {
        bubble = (GameObject)Instantiate(Resources.Load("bubble"));
        bubble.SetActive(false);
        bubble.transform.localScale = new Vector3(0.2f, 0.2f, 0);
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {

            bubbleHappen = true;

            if (Social.localUser.authenticated)
                PlayGamesScript.IncrementAchievement(GPGSIds.achievement_bubble_power, 2);

            bubble.SetActive(true);            

            gameObject.SetActive(false);
        }
    }
}
