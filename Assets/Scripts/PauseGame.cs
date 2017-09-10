using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

    private bool pause = false;
    public GameObject PauseGameText;
   
	// Use this for initialization
	void Start () {
       
	}

    private void Update() {
        if (pause) {
            AudioListener.pause = true;
        } else {
            AudioListener.pause = false;
        }
    }

    public void Pause() {
        if (pause == false) {
            pause = true;
            Time.timeScale = 0;
            PauseGameText.SetActive(true);
            return;
        }

        if (pause == true) {
            pause = false;
            Time.timeScale = 1;
            PauseGameText.SetActive(false);
            return;
        }
    }
}
