using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticle : MonoBehaviour, IRecycle {

    public Sprite[] sprites;
    public Vector2 colliderOffset = Vector2.zero;


    public void Restart() {
        var renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[UnityEngine.Random.Range(0, sprites.Length)];

        var collider = GetComponent<BoxCollider2D>();
        collider.size = (renderer.bounds.size) * 3;
        //size.y += colliderOffset.y;

        //collider.size = size;
        //collider.offset = new Vector2(-colliderOffset.x, (collider.size.y / 2) - colliderOffset.y);
    }

    public void Shutdown() {
        
    }

}
