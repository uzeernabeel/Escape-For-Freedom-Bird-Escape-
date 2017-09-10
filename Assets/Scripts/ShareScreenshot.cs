using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class ShareScreenshot : MonoBehaviour {

    private bool isProcessing = false;
    public float startX;
    public float startY;
    public int valueX;
    public int valueY;



    public void shareScreenshot() {

        if (!isProcessing && GameObject.Find("Ask Friend").GetComponent<Image>().enabled)
            StartCoroutine(captureScreenshot());
    }

    public IEnumerator captureScreenshot() {
        isProcessing = true;
        yield return new WaitForEndOfFrame();

        Texture2D screenTexture = new Texture2D(Screen.width * valueX / 10000, Screen.height * valueY / 10000, TextureFormat.RGB24, true);

        // put buffer into texture
        //screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height),0,0);
        //create a Rect object as per your needs.
        screenTexture.ReadPixels(new Rect
                                 (Screen.width * startX, (Screen.height * startY), Screen.width * valueX / 10000, Screen.height * valueY / 10000), 0, 0);

        // apply
        screenTexture.Apply();

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO

        //byte[] dataToSave = Resources.Load<TextAsset>("everton").bytes;
        byte[] dataToSave = screenTexture.EncodeToPNG();

        string destination = Path.Combine(Application.persistentDataPath, System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");

        File.WriteAllBytes(destination, dataToSave);


        if (!Application.isEditor) {
            // block to open the file and share it ------------START
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "Which Football Club does this Rebus represent?\n" +
                                                 "Download the game on play store at " + "\nhttps://play.google.com/store/apps/details?id=com.TGC.RebusFC&pcampaignid=GPC_shareGame");
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "Which club is this?");
            intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

            // option one WITHOUT chooser:
            currentActivity.Call("startActivity", intentObject);

            // block to open the file and share it ------------END

        }
        isProcessing = false;

    }
}