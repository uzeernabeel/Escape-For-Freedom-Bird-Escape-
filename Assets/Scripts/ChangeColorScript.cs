using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorScript : MonoBehaviour {
    public SpriteRenderer sprite;
    public float colorNumber;
    public float colorNumber2;
        
    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        colorNumber -= Time.deltaTime / 4;
        colorNumber2 += Time.deltaTime / 2;

        if (colorNumber <= 0.25)
            colorNumber = 1f;

        if (colorNumber2 > 1)
            colorNumber2 = 0;

        sprite.color = new Color(colorNumber, colorNumber2, 0);

	}
}
