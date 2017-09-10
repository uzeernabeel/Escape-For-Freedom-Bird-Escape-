using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToContinue : MonoBehaviour {

    public int scene = 1;
    private bool loadLock;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        

	}

    public void PlayerClickedToPlay() {
        if (!loadLock) {
            loadLock = true;

            object3.SetActive(true);
            object4.SetActive(false);
            object5.SetActive(true);

            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene() {
        
        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync(scene);
       
        while (!async.isDone)
            yield return null;

        //SceneManager.LoadScene(scene);
    }
}
