using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour {

    public GameObject player;
    public GameObject background;

    private void Awake() {

        //background = (GameObject)Instantiate(Resources.Load("Scenery2"));

        if (StratScreenUI.dragonBird && PlayerPrefs.GetInt("Player") == 4) {
            player = (GameObject)Instantiate(Resources.Load("dragonBird"));
            if (PlayerPrefs.GetInt("DragonBirdColor") == 1)
                player.GetComponent<SpriteRenderer>().color = new Color(.43f, .53f, 1f, 1f);
            if (PlayerPrefs.GetInt("DragonBirdColor") == 2)
                player.GetComponent<SpriteRenderer>().color = new Color(1f, .43f, .43f, 1f);
            if (PlayerPrefs.GetInt("DragonrBirdColor") == 3)
                player.GetComponent<SpriteRenderer>().color = new Color(.17f, 1, .17f, 1f);
        } else if (StratScreenUI.blueBird && PlayerPrefs.GetInt("Player") == 3) {
            player = (GameObject)Instantiate(Resources.Load("BlueBird"));
            if (PlayerPrefs.GetInt("BlueBirdColor") == 1)
                player.GetComponent<SpriteRenderer>().color = new Color(.28f, .3f, 1f, 1f);
            if (PlayerPrefs.GetInt("BlueBirdColor") == 2)
                player.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
            if (PlayerPrefs.GetInt("BlueBirdColor") == 3)
                player.GetComponent<SpriteRenderer>().color = new Color(.1f, 1f, .22f, 1f);
        } else if (StratScreenUI.eagle && PlayerPrefs.GetInt("Player") == 2) {
            player = (GameObject)Instantiate(Resources.Load("Eagle"));
            if (PlayerPrefs.GetInt("EagleBirdColor") == 1)
                player.GetComponent<SpriteRenderer>().color = new Color(.24f, .25f, 1f, 1f);
            if (PlayerPrefs.GetInt("EagleBirdColor") == 2)
                player.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
            if (PlayerPrefs.GetInt("EagleBirdColor") == 3)
                player.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
        } else if (StratScreenUI.Pidgetto && PlayerPrefs.GetInt("Player") == 1) {
            player = (GameObject)Instantiate(Resources.Load("Pidgeotto"));
            if (PlayerPrefs.GetInt("PidgottoColor") == 1)
                player.GetComponent<SpriteRenderer>().color = new Color(0f, .47f, 1f, 1f);
            if (PlayerPrefs.GetInt("PidgottoColor") == 2)
                player.GetComponent<SpriteRenderer>().color = new Color(.96f, .23f, .23f, 1f);
            if (PlayerPrefs.GetInt("PidgottoColor") == 3)
                player.GetComponent<SpriteRenderer>().color = new Color(.23f, .97f, .54f, 1f);
        } else{
            player = (GameObject)Instantiate(Resources.Load("Bird"));
            if (PlayerPrefs.GetInt("PaperBirdColor") == 1)
                player.GetComponent<SpriteRenderer>().color = Color.yellow;
            else if (PlayerPrefs.GetInt("PaperBirdColor") == 2)
                player.GetComponent<SpriteRenderer>().color = new Color(1f, .4f, .4f, 1f);
            else if (PlayerPrefs.GetInt("PaperBirdColor") == 3)
                player.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f, 1f);
        }
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
