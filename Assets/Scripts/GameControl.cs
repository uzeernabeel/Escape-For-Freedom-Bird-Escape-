using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameControl : MonoBehaviour {

    public static GameControl instance;         //A reference to our game control script so we can access it statically.

    public Text scoreText;                      //A reference to the UI text component that displays the player's score.
    public Text scoreText1;
    public Text totalText;
    public Text BestScore;
    public Text BestScore1;
    public Text Coins;
    public Text animateCoin;
    public Text GameOverText;
    public Text LevelText;
    public Text TotalCoins;

    public GameObject gameOvertext;             
    public GameObject AfterGameOver;
    public GameObject QuitScreen;
    public Image highScoreScreen;

    public GameObject loadingText;

    public GameObject shareButton;
    
    public bool coinCollect;
    public bool runnerAppear;                   //time for sonic to run.
    public float coins;
    public bool gameOver = false;               //Is the game over?
    public float totalScore;
    public float totalCoins;
    public float levelNumber;
    public float scrollSpeed = -5f;

    public float timeRemaining = 3f;
    
    //public Spawner spawner;

    //score[distance] and highScore [best distance].
    public float timeElapsed = 0f;
    public float bestTime = 0f;

    private bool bestBestTime;

    public String textColor;

    public AudioSource source;
    public AudioClip clip;
    public AudioClip PlayerDieSound;

    public GameObject music;


    void Awake() {
        //spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        //AfterGameOver = GameObject.Find("AfterGameOver");
        music = GameObject.Find("BackgroundMusic");
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);

    }

    private static int GetSDKLevel() {
        var clazz = AndroidJNI.FindClass("android.os.Build$VERSION");
        var fieldID = AndroidJNI.GetStaticFieldID(clazz, "SDK_INT", "I");
        var sdkLevel = AndroidJNI.GetStaticIntField(clazz, fieldID);
        return sdkLevel;
    }

private void Start() {

        TotalCoins.text = (PlayerPrefs.GetFloat("TotalCoins")).ToString();
        bestTime = PlayerPrefs.GetFloat("BestTime");
        totalScore = PlayerPrefs.GetFloat("TotalScore");
        totalCoins = PlayerPrefs.GetFloat("TotalCoins");
        levelNumber = PlayerPrefs.GetFloat("PlayerLevel");
        BestScore.text = "Best Score: " + FormatTime(bestTime);
        //PlayGamesScript.UnlockAchievement(GPGSIds.achievement_fresh_start);

    }

    void Update() {

        if (Input.GetKey(KeyCode.Escape)) {
            Time.timeScale = 0;
            QuitScreen.SetActive(true);
        }

        //If the game is over and the player has pressed some input...
        if (gameOver && Input.GetMouseButtonDown(0)) {
            //...reload the current scene.

            AfterGameOver.SetActive(true);
            if (source.gameObject.activeSelf == false)
                source.gameObject.SetActive(true);
            source.Stop();
            source.PlayOneShot(PlayerDieSound);

            //if (GetSDKLevel() >= 24) {
            //    shareButton.SetActive(false);
            //}


            //spawner.active = true;
            timeElapsed = 0;
            bestBestTime = false;
            ScrollingObject.time = 0;
           
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (!gameOver) {
            timeElapsed += (-ScrollingObject.scrollSpeed) * (Time.deltaTime);
            scoreText.text = "Score: " + FormatTime(timeElapsed) + "M";
            Coins.text = "= " + FormatTime(coins);

            if (coinCollect) {
                animateCoin.gameObject.SetActive(true);
            }

            timeRemaining -= Time.deltaTime;

            if (Social.localUser.authenticated) {
                if (coins >= 15)
                    PlayGamesScript.UnlockAchievement(GPGSIds.achievement_coins_in_one_run_1);
                if(coins >= 30)
                    PlayGamesScript.UnlockAchievement(GPGSIds.achievement_coins_in_one_run_2);

            }

            if (timeRemaining < 0) { 
                coinCollect = false;
                animateCoin.gameObject.SetActive(false);
                timeRemaining = 0;
            }
        }

        textColor = bestBestTime ? "#FF0" : "#000";


    }

    public void NoButtonSelected() {
        QuitScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void YesButtonSelected() {
        Application.Quit();
    }

    public void BirdScored() {
        //The bird can't score if the game is over.
        if (gameOver)
            return;
        
    }

    public void BirdDied() {

        if (BubbleCollect.bubbleHappen) {
            BubbleCollect.bubbleHappen = false;

            //Debug.Log("Bubble Goes away and player don't die");
            return;
        }

        BigPower.bigPowerHappen = false;
        BigPowerOpposite.smallPowerHappen = false;
        PowerCollect.done = false;

        //first time die Achievement unlock
        if(Social.localUser.authenticated)
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_first_time_dead_rip);

        source.PlayOneShot(clip, .75f);

        //gameover text is active.
        GameOverText.gameObject.SetActive(true);
        //Set the game to be over.
        gameOver = true;
        //spawner.active = false;

        //saving coins
        totalCoins += coins;
        PlayerPrefs.SetFloat("TotalCoins", totalCoins);

        //saving Total Score.
        totalScore += timeElapsed;
        PlayerPrefs.SetFloat("TotalScore", totalScore);

        if(timeElapsed > bestTime) {
            bestTime = timeElapsed;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            BestScore.color = Color.red;
            highScoreScreen.gameObject.SetActive(true);
        }

        //checking the level and setting it.
        LevelCheck();
        PlayerPrefs.SetFloat("PlayerLevel", levelNumber);

        if (Social.localUser.authenticated) {
            //checking the Escape distance and unlocking the achievement #Escape Distance.
            AfterLevelCheck();
            DistanceCheck();
            AfterDistanceCheck();
            CoinCheck();
        }

        //showing the score in gave over object.
        scoreText.text = "Score: " + FormatTime(timeElapsed) + "M";
        scoreText1.text = FormatTime(timeElapsed);
        BestScore.text = "Best Score: " + FormatTime(bestTime) + "M";
        BestScore1.text = FormatTime(bestTime);
        LevelText.text = levelNumber.ToString();
        totalScore = (int)totalScore;
        totalText.text = totalScore.ToString();
        Coins.text =  "= " + FormatTime(coins);
        TotalCoins.text = (PlayerPrefs.GetFloat("TotalCoins")).ToString();

        music.SetActive(false);

        if (Social.localUser.authenticated) {
            //adding score to leaderBoard of Google #Longest Escape
            PlayGamesScript.AddScoreToLeaderboard(GPGSIds.leaderboard_longest_escape, (long)bestTime);

            //adding socre to leaderBoard of Google #Total distance
            PlayGamesScript.AddScoreToLeaderboard(GPGSIds.leaderboard_total_escape_distance, (long)totalScore);
        }
    }

   
    public void RestartGame() {
        timeElapsed = 0;
        coins = 0;
        bestBestTime = false;
        ScrollingObject.time = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public string FormatTime(float value) {
        int t = (int)value;

        if (value > 999) {
            return String.Format("{0:D4}", t);
        } else if (value > 99) {
            return String.Format("{0:D3}", t);
        } else {
            return String.Format("{0:D2}", t);
        }
        //return value.ToString().
    }

    public void GoBackToMainMenu() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        StartCoroutine(LoadScene());
        loadingText.SetActive(true);
    }

    IEnumerator LoadScene() {

        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync(0);

        while (!async.isDone)
            yield return null;

        //SceneManager.LoadScene(scene);
    }

    public void LevelCheck() {
        if (totalScore > 100000)
            levelNumber = 50;
        else if (totalScore > 95000)
            levelNumber = 40;
        else if (totalScore > 90000)
            levelNumber = 39;
        else if (totalScore > 85000)
            levelNumber = 38;
        else if (totalScore > 80000)
            levelNumber = 37;
        else if (totalScore > 75000)
            levelNumber = 36;
        else if (totalScore > 70000)
            levelNumber = 35;
        else if (totalScore > 65000)
            levelNumber = 34;
        else if (totalScore > 60000)
            levelNumber = 33;
        else if (totalScore > 55000)
            levelNumber = 32;
        else if (totalScore > 50000)
            levelNumber = 31;
        else if (totalScore > 45000)
            levelNumber = 30;
        else if (totalScore > 40000)
            levelNumber = 29;
        else if (totalScore > 35000)
            levelNumber = 28;
        else if (totalScore > 30000)
            levelNumber = 27;
        else if (totalScore > 25000)
            levelNumber = 26;
        else if (totalScore > 20000)
            levelNumber = 25;
        else if (totalScore > 18000)
            levelNumber = 24;
        else if (totalScore > 15000)
            levelNumber = 23;
        else if (totalScore > 12000)
            levelNumber = 22;
        else if (totalScore > 10000)
            levelNumber = 21;
        else if (totalScore > 9500)
            levelNumber = 20;
        else if (totalScore > 9000)
            levelNumber = 19;
        else if (totalScore > 8500)
            levelNumber = 18;
        else if (totalScore > 8000)
            levelNumber = 17;
        else if (totalScore > 7500)
            levelNumber = 16;
        else if (totalScore > 7000)
            levelNumber = 15;
        else if (totalScore > 6500)
            levelNumber = 14;
        else if (totalScore > 6000)
            levelNumber = 13;
        else if (totalScore > 5500)
            levelNumber = 12;
        else if (totalScore > 5000)
            levelNumber = 11;
        else if (totalScore > 4500)
            levelNumber = 10;
        else if (totalScore > 4000)
            levelNumber = 9;
        else if (totalScore > 3500)
            levelNumber = 8;
        else if (totalScore > 3000)
            levelNumber = 7;
        else if (totalScore > 2500)
            levelNumber = 6;
        else if (totalScore > 2000)
            levelNumber = 5;
        else if (totalScore > 1500)
            levelNumber = 4;
        else if (totalScore > 1000)
            levelNumber = 3;
        else if (totalScore > 500)
            levelNumber = 2;
        else if (totalScore > 200)
            levelNumber = 1;
    }

    public void AfterLevelCheck() {
        if (levelNumber >= 15)
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_level_up_1_reach_level_15);
        if(levelNumber >= 30)
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_level_up_2_reach_level_30);
        if (levelNumber >= 40)
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_level_up_3_reach_level_40__champion_levels);
    }

    public void AfterDistanceCheck() {
        if (bestTime >= 300)
            PlayerPrefs.SetInt("Achievement1", 1);
        if (bestTime >= 600)
            PlayerPrefs.SetInt("Achievement2", 1);
        if (bestTime >= 900)
            PlayerPrefs.SetInt("Achievement3", 1);
        if (bestTime >= 1200)
            PlayerPrefs.SetInt("Achievement4", 1);
        if (bestTime >= 1500)
            PlayerPrefs.SetInt("Achievement5", 1);
        if (bestTime >= 1800)
            PlayerPrefs.SetInt("Achievement6", 1);
        if (bestTime >= 2100)
            PlayerPrefs.SetInt("Achievement7", 1);
        if (bestTime >= 2500)
            PlayerPrefs.SetInt("Achievement8", 1);
    }

    public void DistanceCheck() {
        if(bestTime >= 2500 && PlayerPrefs.GetInt("Achievement9") == 0) {
            PlayGamesScript.IncrementAchievement(GPGSIds.achievement_escape_distance_3_master_escapist, 1);
        }
        if (bestTime >= 2100 && PlayerPrefs.GetInt("Achievement7") == 0) {
            PlayGamesScript.IncrementAchievement(GPGSIds.achievement_escape_distance_3_master_escapist, 1);
        }
        if (bestTime >= 1800 && PlayerPrefs.GetInt("Achievement6") == 0) {
            PlayGamesScript.IncrementAchievement(GPGSIds.achievement_escape_distance_2_moderate_learner, 1);
        }
        if (bestTime >= 1500 && PlayerPrefs.GetInt("Achievement5") == 0) {
            PlayGamesScript.IncrementAchievement(GPGSIds.achievement_escape_distance_2_moderate_learner, 1);
        }
        if (bestTime >= 1200 && PlayerPrefs.GetInt("Achievement4") == 0) {
            PlayGamesScript.IncrementAchievement(GPGSIds.achievement_escape_distance_2_moderate_learner, 1);
        }
        if (bestTime >= 900 && PlayerPrefs.GetInt("Achievement3") == 0) {
            PlayGamesScript.IncrementAchievement(GPGSIds.achievement_escape_distance_1_starting_to_learn, 1);
        }
        if (bestTime >= 600 && PlayerPrefs.GetInt("Achievement2") == 0) {
            PlayGamesScript.IncrementAchievement(GPGSIds.achievement_escape_distance_1_starting_to_learn, 1);
        }
        if (bestTime >= 300 && PlayerPrefs.GetInt("Achievement1") == 0) {
            PlayGamesScript.IncrementAchievement(GPGSIds.achievement_escape_distance_1_starting_to_learn, 1);
        }
    }

    public void CoinCheck() {
        if (totalCoins >= 50)
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_coin_collector_1_lower_class);
        if (totalCoins >= 100)
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_coin_collector_2_middle_class);
        if (totalCoins >= 250)
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_coin_collector_3_elite_class);
    }
}