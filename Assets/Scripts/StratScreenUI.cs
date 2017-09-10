using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StratScreenUI : MonoBehaviour {

    public GameObject InfoScreen;
    public GameObject Store;
    public GameObject AreYouSure;
    public GameObject AreYouSure2;
    public GameObject AreYouSure3;
    public GameObject AreYouSure4;
    public GameObject creditScreen;

    public GameObject VideoButton;
    public GameObject notConnectedToInternet;

    public Text totalCoin;
    public Text PidgeattoUnlocked;
    public Text EagleUnlocked;
    public Text BlueBirdUnlocked;
    public Text DragonUnlocked;
    

    public static bool paperBird;
    public static bool Pidgetto;
    public static bool eagle;
    public static bool blueBird;
    public static bool dragonBird;

    public bool pidgeattoBought;
    public bool pidgeattoColor1Bought;
    public bool pidgeattoColor2Bought;
    public bool pidgeattoColor3Bought;
    public bool eagleBought;
    public bool eagleColor1Bought;
    public bool eagleColor2Bought;
    public bool eagleColor3Bought;
    public bool buleBirdBought;
    public bool blueBirdColor1Bought;
    public bool blueBirdColor2Bought;
    public bool blueBirdColor3Bought;
    public bool dragonBought;
    public bool dragonColor1Bought;
    public bool dragonColor2Bought;
    public bool dragonColor3Bought;
   
    public AudioSource source;
    public AudioClip notEnoughCash;
    public AudioClip strangerStranger;
    public AudioClip welcome;
    public AudioClip comeBack;
    public AudioClip isThatAll;
    public AudioClip strangerWhatYou;
    public AudioClip Thankyou;

    // Use this for initialization
    void Start () {

        //GetComponent<RawImage>().texture = EndVideo as MovieTexture;

        source = GetComponent<AudioSource>();

        /*PlayerPrefs.SetInt("BlueBird", 0);
        PlayerPrefs.SetInt("Dragon", 0);
        PlayerPrefs.SetInt("Pidgeatto", 0);
        PlayerPrefs.SetInt("Eagle", 0);
        PlayerPrefs.SetFloat("TotalCoins", 1500);*/

        totalCoin.text = PlayerPrefs.GetFloat("TotalCoins").ToString();

        if (PlayerPrefs.GetInt("Pidgeatto") == 1)
            PidgeattoUnlocked.text = "Unlocked";

        if (PlayerPrefs.GetInt("Eagle") == 1)
            EagleUnlocked.text = "Unlocked";

        if (PlayerPrefs.GetInt("BlueBird") == 1)
            BlueBirdUnlocked.text = "Unlocked";

        if (PlayerPrefs.GetInt("Dragon") == 1)
            DragonUnlocked.text = "Unlocked";
    }


	
	// Update is called once per frame
	void Update () {
		
	}

    public void InternetVideoButtonClicked() {
        if (InternetChecker.internetConnectBool)
            Application.OpenURL("https://www.youtube.com/watch?v=KacrQAx2Q5Q");
        else
            notConnectedToInternet.SetActive(true);
    }

    public void InternetStartVideoButtonClicked() {
        if (InternetChecker.internetConnectBool)
            Application.OpenURL("https://www.youtube.com/watch?v=JeCsZ1Bo8BY");
        else
            notConnectedToInternet.SetActive(true);
    }

    public void InternetEndVideoButtonClicked() {
        if (InternetChecker.internetConnectBool)
            Application.OpenURL("https://www.youtube.com/watch?v=c3Tli5g0FgA");
        else
            notConnectedToInternet.SetActive(true);
    }

    public void InternetVideoCloseButtonClicked() {
        notConnectedToInternet.SetActive(false);
    }

    public void VideoCloseButton() {
        DestroyObject(VideoButton);
    }

    public void CreditButtonClicked() {
        creditScreen.SetActive(true);
        source.PlayOneShot(Thankyou, 1f);
    }

    public void CreditCloseButtonClicked() {
        creditScreen.SetActive(false);
        source.PlayOneShot(comeBack, 1f);
    }

    public void InfoScreenButton() {
        InfoScreen.SetActive(true);
        source.PlayOneShot(isThatAll, 1f);
    }

    public void InfoScreenCloseButton() {
        InfoScreen.SetActive(false);
        source.PlayOneShot(comeBack, 1f);
    }

    public void StoreButtonClicked() {
        Store.SetActive(true);
        source.PlayOneShot(welcome, 1f);
    }

    public void StoreCloseButtonClicked() {
        Store.SetActive(false);
        source.PlayOneShot(comeBack, 1f); 
    }

    public void PaperBirdSelected() {
        source.PlayOneShot(isThatAll, 1f);
        PlayerPrefs.SetInt("Player", 0);
        paperBird = true;
        Pidgetto = false;
        eagle = false;
        blueBird = false;
        dragonBird = false;

        PlayerPrefs.SetInt("PaperBirdColor", 0);
    }

    public void PaperBirdColor1Selected() {
        source.PlayOneShot(isThatAll, 1f);
        PlayerPrefs.SetInt("Player", 0);

        paperBird = true;
        Pidgetto = false;
        eagle = false;
        blueBird = false;
        dragonBird = false;

        PlayerPrefs.SetInt("PaperBirdColor", 1);
    }

    public void PaperBirdColor2Selected() {
        source.PlayOneShot(isThatAll, 1f);
        PlayerPrefs.SetInt("Player", 0);
        paperBird = true;
        Pidgetto = false;
        eagle = false;
        blueBird = false;
        dragonBird = false;

        PlayerPrefs.SetInt("PaperBirdColor", 2);
    }

    public void PaperBirdColor3Selected() {
        source.PlayOneShot(isThatAll, 1f);
        PlayerPrefs.SetInt("Player", 0);
        paperBird = true;
        Pidgetto = false;
        eagle = false;
        blueBird = false;
        dragonBird = false;

        PlayerPrefs.SetInt("PaperBirdColor", 3);
    }

    public void PidgeattoSelected() {
   
        if (PlayerPrefs.GetInt("Pidgeatto") == 0) {
            if (PlayerPrefs.GetFloat("TotalCoins") >= 150) {
                source.PlayOneShot(strangerStranger, 1f);
                AreYouSure.SetActive(true);
            } else
                source.PlayOneShot(notEnoughCash, 1f);
        } else if(PlayerPrefs.GetInt("Pidgeatto") == 1) {
            source.PlayOneShot(isThatAll, 1f);
            PlayerPrefs.SetInt("Player", 1);
            PlayerPrefs.SetInt("PidgottoColor", 0);
            paperBird = false;
            Pidgetto = true;
            eagle = false;
            blueBird = false;
            dragonBird = false;
        } else
            source.PlayOneShot(notEnoughCash, 1f);

    }

    public void PidgeattoColor1Selected() {

        if (PlayerPrefs.GetInt("Pidgeatto") == 0) {
            if (PlayerPrefs.GetFloat("TotalCoins") >= 150) {
                source.PlayOneShot(strangerStranger, 1f);
                AreYouSure.SetActive(true);
            } else
                source.PlayOneShot(notEnoughCash, 1f);
        } else if (PlayerPrefs.GetInt("Pidgeatto") == 1) {
            source.PlayOneShot(isThatAll, 1f);
            PlayerPrefs.SetInt("Player", 1);
            PlayerPrefs.SetInt("PidgottoColor", 1);
            paperBird = false;
            Pidgetto = true;
            eagle = false;
            blueBird = false;
            dragonBird = false;
        } else
            source.PlayOneShot(notEnoughCash, 1f);

    }

    public void PidgeattoColor2Selected() {

        if (PlayerPrefs.GetInt("Pidgeatto") == 0) {
            if (PlayerPrefs.GetFloat("TotalCoins") >= 150) {
                source.PlayOneShot(strangerStranger, 1f);
                AreYouSure.SetActive(true);
            } else
                source.PlayOneShot(notEnoughCash, 1f);
        } else if (PlayerPrefs.GetInt("Pidgeatto") == 1) {
            source.PlayOneShot(isThatAll, 1f);
            PlayerPrefs.SetInt("Player", 1);
            PlayerPrefs.SetInt("PidgottoColor", 2);
            paperBird = false;
            Pidgetto = true;
            eagle = false;
            blueBird = false;
            dragonBird = false;
        } else
            source.PlayOneShot(notEnoughCash, 1f);

    }

    public void PidgeattoColor3Selected() {

        if (PlayerPrefs.GetInt("Pidgeatto") == 0) {
            if (PlayerPrefs.GetFloat("TotalCoins") >= 150) {
                source.PlayOneShot(strangerStranger, 1f);
                AreYouSure.SetActive(true);
            } else
                source.PlayOneShot(notEnoughCash, 1f);
        } else if (PlayerPrefs.GetInt("Pidgeatto") == 1) {
            source.PlayOneShot(isThatAll, 1f);
            PlayerPrefs.SetInt("Player", 1);
            PlayerPrefs.SetInt("PidgottoColor", 3);
            paperBird = false;
            Pidgetto = true;
            eagle = false;
            blueBird = false;
            dragonBird = false;
        } else
            source.PlayOneShot(notEnoughCash, 1f);

    }

    public void EagleSelected() {

        if (PlayerPrefs.GetInt("Eagle") == 0) {
            if (PlayerPrefs.GetFloat("TotalCoins") >= 250) {
                source.PlayOneShot(strangerWhatYou, 1f);
                AreYouSure2.SetActive(true);
            } else
                source.PlayOneShot(notEnoughCash, 1f);
        } else if (PlayerPrefs.GetInt("Eagle") == 1) {
            source.PlayOneShot(isThatAll, 1f);
            PlayerPrefs.SetInt("Player", 2);
            PlayerPrefs.SetInt("EagleBirdColor", 0);
            paperBird = false;
            Pidgetto = false;
            eagle = true;
            blueBird = false;
            dragonBird = false;
        } else
            source.PlayOneShot(notEnoughCash, 1f);

    }

    public void EagleColor1Selected() {

        if (PlayerPrefs.GetInt("Eagle") == 0) {
            if (PlayerPrefs.GetFloat("TotalCoins") >= 250) {
                source.PlayOneShot(strangerWhatYou, 1f);
                AreYouSure2.SetActive(true);
            } else
                source.PlayOneShot(notEnoughCash, 1f);
        } else if (PlayerPrefs.GetInt("Eagle") == 1) {
            source.PlayOneShot(isThatAll, 1f);
            PlayerPrefs.SetInt("Player", 2);
            PlayerPrefs.SetInt("EagleBirdColor", 1);
            paperBird = false;
            Pidgetto = false;
            eagle = true;
            blueBird = false;
            dragonBird = false;
        } else
            source.PlayOneShot(notEnoughCash, 1f);

    }

    public void EagleColor2Selected() {

        if (PlayerPrefs.GetInt("Eagle") == 0) {
            if (PlayerPrefs.GetFloat("TotalCoins") >= 250) {
                source.PlayOneShot(strangerWhatYou, 1f);
                AreYouSure2.SetActive(true);
            } else
                source.PlayOneShot(notEnoughCash, 1f);
        } else if (PlayerPrefs.GetInt("Eagle") == 1) {
            source.PlayOneShot(isThatAll, 1f);
            PlayerPrefs.SetInt("Player", 2);
            PlayerPrefs.SetInt("EagleBirdColor", 2);
            paperBird = false;
            Pidgetto = false;
            eagle = true;
            blueBird = false;
            dragonBird = false;
        } else
            source.PlayOneShot(notEnoughCash, 1f);

    }

    public void EagleColor3Selected() {

        if (PlayerPrefs.GetInt("Eagle") == 0) {
            if (PlayerPrefs.GetFloat("TotalCoins") >= 250) {
                source.PlayOneShot(strangerWhatYou, 1f);
                AreYouSure2.SetActive(true);
            } else
                source.PlayOneShot(notEnoughCash, 1f);
        } else if (PlayerPrefs.GetInt("Eagle") == 1) {
            source.PlayOneShot(isThatAll, 1f);
            PlayerPrefs.SetInt("Player", 2);
            PlayerPrefs.SetInt("EagleBirdColor", 3);
            paperBird = false;
            Pidgetto = false;
            eagle = true;
            blueBird = false;
            dragonBird = false;
        } else
            source.PlayOneShot(notEnoughCash, 1f);

    }

    public void BlueBirdSelected() {

        if (PlayerPrefs.GetInt("BlueBird") == 0) {
            if (PlayerPrefs.GetFloat("TotalCoins") >= 350) {
                source.PlayOneShot(strangerStranger, 1f);
                AreYouSure3.SetActive(true);
            } else
                source.PlayOneShot(notEnoughCash, 1f);
        } else if (PlayerPrefs.GetInt("BlueBird") == 1) {
            source.PlayOneShot(isThatAll, 1f);
            PlayerPrefs.SetInt("Player", 3);
            PlayerPrefs.SetInt("BlueBirdColor", 0);
            paperBird = false;
            Pidgetto = false;
            eagle = false;
            blueBird = true;
            dragonBird = false;
        } else
            source.PlayOneShot(notEnoughCash, 1f);
    }

    public void BlueBirdColor1Selected() {

        if (PlayerPrefs.GetInt("BlueBird") == 0) {
            if (PlayerPrefs.GetFloat("TotalCoins") >= 350) {
                source.PlayOneShot(strangerStranger, 1f);
                AreYouSure3.SetActive(true);
            } else
                source.PlayOneShot(notEnoughCash, 1f);
        } else if (PlayerPrefs.GetInt("BlueBird") == 1) {
            source.PlayOneShot(isThatAll, 1f);
            PlayerPrefs.SetInt("Player", 3);
            PlayerPrefs.SetInt("BlueBirdColor", 1);
            paperBird = false;
            Pidgetto = false;
            eagle = false;
            blueBird = true;
            dragonBird = false;
        } else
            source.PlayOneShot(notEnoughCash, 1f);
    }

    public void BlueBirdColor2Selected() {

        if (PlayerPrefs.GetInt("BlueBird") == 0) {
            if (PlayerPrefs.GetFloat("TotalCoins") >= 350) {
                source.PlayOneShot(strangerStranger, 1f);
                AreYouSure3.SetActive(true);
            } else
                source.PlayOneShot(notEnoughCash, 1f);
        } else if (PlayerPrefs.GetInt("BlueBird") == 1) {
            source.PlayOneShot(isThatAll, 1f);
            PlayerPrefs.SetInt("Player", 3);
            PlayerPrefs.SetInt("BlueBirdColor", 2);
            paperBird = false;
            Pidgetto = false;
            eagle = false;
            blueBird = true;
            dragonBird = false;
        } else
            source.PlayOneShot(notEnoughCash, 1f);
    }

    public void BlueBirdColor3Selected() {

        if (PlayerPrefs.GetInt("BlueBird") == 0) {
            if (PlayerPrefs.GetFloat("TotalCoins") >= 350) {
                source.PlayOneShot(strangerStranger, 1f);
                AreYouSure3.SetActive(true);
            } else
                source.PlayOneShot(notEnoughCash, 1f);
        } else if (PlayerPrefs.GetInt("BlueBird") == 1) {
            source.PlayOneShot(isThatAll, 1f);
            PlayerPrefs.SetInt("Player", 3);
            PlayerPrefs.SetInt("BlueBirdColor", 3);
            paperBird = false;
            Pidgetto = false;
            eagle = false;
            blueBird = true;
            dragonBird = false;
        } else
            source.PlayOneShot(notEnoughCash, 1f);
    }


    public void DragonBirdSelected() {

        if (PlayerPrefs.GetInt("Dragon") == 0) {
            if (PlayerPrefs.GetFloat("TotalCoins") >= 500) {
                source.PlayOneShot(strangerWhatYou, 1f);
                AreYouSure4.SetActive(true);
            } else
                source.PlayOneShot(notEnoughCash, 1f);
        } else if (PlayerPrefs.GetInt("Dragon") == 1) {
            source.PlayOneShot(isThatAll, 1f);
            PlayerPrefs.SetInt("Player", 4);
            PlayerPrefs.SetInt("DragonrBirdColor", 0);
            paperBird = false;
            Pidgetto = false;
            eagle = false;
            blueBird = false;
            dragonBird = true;
        } else
            source.PlayOneShot(notEnoughCash, 1f);
    }

    public void DragonBirdColor1Selected() {

        if (PlayerPrefs.GetInt("Dragon") == 0) {
            if (PlayerPrefs.GetFloat("TotalCoins") >= 500) {
                source.PlayOneShot(strangerWhatYou, 1f);
                AreYouSure4.SetActive(true);
            } else
                source.PlayOneShot(notEnoughCash, 1f);
        } else if (PlayerPrefs.GetInt("Dragon") == 1) {
            source.PlayOneShot(isThatAll, 1f);
            PlayerPrefs.SetInt("Player", 4);
            PlayerPrefs.SetInt("DragonrBirdColor", 1);
            paperBird = false;
            Pidgetto = false;
            eagle = false;
            blueBird = false;
            dragonBird = true;
        } else
            source.PlayOneShot(notEnoughCash, 1f);
    }

    public void DragonBirdColor2Selected() {

        if (PlayerPrefs.GetInt("Dragon") == 0) {
            if (PlayerPrefs.GetFloat("TotalCoins") >= 500) {
                source.PlayOneShot(strangerWhatYou, 1f);
                AreYouSure4.SetActive(true);
            } else
                source.PlayOneShot(notEnoughCash, 1f);
        } else if (PlayerPrefs.GetInt("Dragon") == 1) {
            source.PlayOneShot(isThatAll, 1f);
            PlayerPrefs.SetInt("Player", 4);
            PlayerPrefs.SetInt("DragonrBirdColor", 2);
            paperBird = false;
            Pidgetto = false;
            eagle = false;
            blueBird = false;
            dragonBird = true;
        } else
            source.PlayOneShot(notEnoughCash, 1f);
    }

    public void DragonBirdColor3Selected() {

        if (PlayerPrefs.GetInt("Dragon") == 0) {
            if (PlayerPrefs.GetFloat("TotalCoins") >= 500) {
                source.PlayOneShot(strangerWhatYou, 1f);
                AreYouSure4.SetActive(true);
            } else
                source.PlayOneShot(notEnoughCash, 1f);
        } else if (PlayerPrefs.GetInt("Dragon") == 1) {
            source.PlayOneShot(isThatAll, 1f);
            PlayerPrefs.SetInt("Player", 4);
            PlayerPrefs.SetInt("DragonrBirdColor", 3);
            paperBird = false;
            Pidgetto = false;
            eagle = false;
            blueBird = false;
            dragonBird = true;
        } else
            source.PlayOneShot(notEnoughCash, 1f);
    }

    public void YesToPidgeatto() {
        paperBird = false;
        Pidgetto = true;
        eagle = false;
        blueBird = false;
        dragonBird = false;

        PlayerPrefs.SetInt("Pidgeatto", 1);
        float coins2 = PlayerPrefs.GetFloat("TotalCoins");
        coins2 -= 150;
        PlayerPrefs.SetFloat("TotalCoins", coins2);
        totalCoin.text = PlayerPrefs.GetFloat("TotalCoins").ToString();

        source.PlayOneShot(Thankyou, 1f);

        PidgeattoUnlocked.text = "Unlocked";

        if (Social.localUser.authenticated)
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_buy_the_pidgeotto);

        AreYouSure.SetActive(false);
    }

    public void NoToPidgeatto() {
        AreYouSure.SetActive(false);
        source.PlayOneShot(isThatAll, 1f);
    }

    public void YesToEagel() {
        paperBird = false;
        Pidgetto = false;
        eagle = true;
        blueBird = false;
        dragonBird = false;

        PlayerPrefs.SetInt("Eagle", 1);
        float coins = PlayerPrefs.GetFloat("TotalCoins");
        coins -= 250f;
        PlayerPrefs.SetFloat("TotalCoins", coins);

        totalCoin.text = PlayerPrefs.GetFloat("TotalCoins").ToString();

        source.PlayOneShot(Thankyou, 1f);

        EagleUnlocked.text = "Unlocked";

        if(Social.localUser.authenticated)
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_buy_the_eagle);

        AreYouSure2.SetActive(false);
    }

    public void NoToEagle() {
        AreYouSure2.SetActive(false);
        source.PlayOneShot(isThatAll, 1f);
    }

    public void YesToBlueBird() {
        paperBird = false;
        Pidgetto = false;
        eagle = false;
        blueBird = true;
        dragonBird = false;

        PlayerPrefs.SetInt("BlueBird", 1);
        float coins = PlayerPrefs.GetFloat("TotalCoins");
        coins -= 350f;
        PlayerPrefs.SetFloat("TotalCoins", coins);

        totalCoin.text = PlayerPrefs.GetFloat("TotalCoins").ToString();

        source.PlayOneShot(Thankyou, 1f);

        BlueBirdUnlocked.text = "Unlocked";

        AreYouSure3.SetActive(false);
    }

    public void NoToBlueBird() {
        AreYouSure3.SetActive(false);
        source.PlayOneShot(isThatAll, 1f);
    }

    public void YesToDragon() {
        paperBird = false;
        Pidgetto = false;
        eagle = false;
        blueBird = false;
        dragonBird = true;

        PlayerPrefs.SetInt("Dragon", 1);
        float coins = PlayerPrefs.GetFloat("TotalCoins");
        coins -= 500f;
        PlayerPrefs.SetFloat("TotalCoins", coins);

        totalCoin.text = PlayerPrefs.GetFloat("TotalCoins").ToString();

        source.PlayOneShot(Thankyou, 1f);

        DragonUnlocked.text = "Unlocked";

        AreYouSure4.SetActive(false);
    }

    public void NoToDragon() {
        AreYouSure4.SetActive(false);
        source.PlayOneShot(isThatAll, 1f);
    }
}
