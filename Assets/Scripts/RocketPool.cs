using UnityEngine;
using System.Collections;

public class RocketPool : MonoBehaviour {
    public GameObject[] obstacle;

    //The column game object.
    public int columnPoolSize = 3;                                  //How many columns to keep on standby.
    //public float spawnRate = 7f;                                    //How quickly columns spawn.
    //public float columnMin = -3.5f;                                   //Minimum y value of the column position.
    //public float columnMax = 3.5f;                                  //Maximum y value of the column position.

    private GameObject[] columns;                                   //Collection of pooled columns.
    private int currentColumn = 0;                                  //Index of the current column in the collection.

    private Vector2 objectPoolPosition = new Vector2(-15, -25);     //A holding position for our unused columns offscreen.
    private float spawnYPosition = -5f;
    private float spawnXPosition = -25f;


    void Start() {
      
        columns = new GameObject[columnPoolSize];
        
        for (int i = 0; i < columnPoolSize; i++) {
            columns[i] = (GameObject)Instantiate(obstacle[i], objectPoolPosition, Quaternion.identity);
        }
    }


    //This spawns columns as long as the game is not over.
    void Update() {

        if (GameControl.instance.gameOver == false && RocketCollect.RocketTime) {

            if (!columns[currentColumn].gameObject.activeSelf)
                columns[currentColumn].gameObject.SetActive(true);

            //...then set the current column to that position.
            if (RocketCollect.RocketTime)
                columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            //columns[currentColumn].transform.Rotate(0, 0, 90); 

            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            currentColumn++;

            RocketCollect.RocketTime = false;

            if (currentColumn >= columnPoolSize) {
                currentColumn = 0;
            }
        }
    }
}