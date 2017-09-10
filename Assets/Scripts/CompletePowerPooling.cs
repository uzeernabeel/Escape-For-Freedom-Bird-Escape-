using UnityEngine;
using System.Collections;

public class CompletePowerPooling : MonoBehaviour {
    //public static CoinPool instance;
    public GameObject[] obstacle;
    //The column game object.
    public int columnPoolSize = 5;                                  //How many columns to keep on standby.
    public float spawnRate = 10f;                                    //How quickly columns spawn.
    public float columnMin = -1f;                                   //Minimum y value of the column position.
    public float columnMax = 3.5f;                                  //Maximum y value of the column position.

    private GameObject[] columns;                                   //Collection of pooled columns.
    private int currentColumn = 0;                                  //Index of the current column in the collection.

    private Vector2 objectPoolPosition = new Vector2(-15, -25);     //A holding position for our unused columns offscreen.
    private float spawnXPosition = 10f;

    private float timeSinceLastSpawned;


    void Start() {
        timeSinceLastSpawned = 0f;

        //Initialize the columns collection.
        columns = new GameObject[columnPoolSize];
        //Loop through the collection... 
        for (int i = 0; i < columnPoolSize; i++) {
            //...and create the individual columns.
            columns[i] = (GameObject)Instantiate(obstacle[Random.Range(0, columnPoolSize)], objectPoolPosition, Quaternion.identity);
        }
    }

    /*private void FixedUpdate() {
        if (currentColumn - 9 == 0) {
            if (obstacle[currentColumn - 1].transform.position.x < -25)
                obstacle[currentColumn - 1].SetActive(false);
            if (obstacle[currentColumn - 2].transform.position.x < -25)
                obstacle[currentColumn - 2].SetActive(false);
            if (obstacle[currentColumn - 3].transform.position.x < -25)
                obstacle[currentColumn - 3].SetActive(false);
            if (obstacle[currentColumn - 4].transform.position.x < -25)
                obstacle[currentColumn - 4].SetActive(false);
            if (obstacle[currentColumn - 5].transform.position.x < -25)
                obstacle[currentColumn - 5].SetActive(false);
            if (obstacle[currentColumn - 7].transform.position.x < -25)
                obstacle[currentColumn - 7].SetActive(false);
            if (obstacle[currentColumn - 8].transform.position.x < -25)
                obstacle[currentColumn - 8].SetActive(false);
            if (obstacle[currentColumn - 9].transform.position.x < -25)
                obstacle[currentColumn - 9].SetActive(false);
        }
    }*/

    //This spawns columns as long as the game is not over.
    void Update() {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) {
            timeSinceLastSpawned = 0f;

            //Set a random y position for the column
            float spawnYPosition = Random.Range(columnMin, columnMax);

            if (!columns[currentColumn].gameObject.activeSelf)
                columns[currentColumn].gameObject.SetActive(true);

            //...then set the current column to that position.
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            currentColumn++;

            if (currentColumn >= columnPoolSize) {
                currentColumn = 0;
            }
        }
    }
}