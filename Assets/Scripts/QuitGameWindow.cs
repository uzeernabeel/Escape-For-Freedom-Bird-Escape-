using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameWindow : MonoBehaviour {

    public GameObject QuitScreen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Escape)) {
            Time.timeScale = 0;
            QuitScreen.SetActive(true);
        }
    }

    public void NoButtonSelected() {
        QuitScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void YesButtonSelected() {
        Application.Quit();
    }

}
