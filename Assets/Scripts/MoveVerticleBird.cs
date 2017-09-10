using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVerticleBird : MonoBehaviour {

    public Rigidbody2D rb2d;

    public float speed1;
    public float speed2;

    public bool rightSide;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if(rightSide)
            rb2d.velocity = new Vector2(Random.Range(2, 5), 0);

        if(!rightSide)
                rb2d.velocity = new Vector2(Random.Range(-2, -5), 0);

        if (rb2d.position.x > 30)
            rb2d.position = new Vector2(Random.Range(-35f, -20f), Random.Range(-5f, 4.5f));

        if (rb2d.position.x < -30)
            rb2d.position = new Vector2(Random.Range(45f, 20f), Random.Range(-5f, 4.5f));

        if (rb2d.position.x > 80 || rb2d.position.x < -80)
            GameObject.DestroyObject(gameObject);
    }
}
