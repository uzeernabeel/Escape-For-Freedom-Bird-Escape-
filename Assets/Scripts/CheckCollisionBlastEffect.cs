using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisionBlastEffect : MonoBehaviour {

    public Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {

            if(anim.gameObject.activeSelf)
            anim.SetTrigger("blast");
            
        }
    }

 
}
