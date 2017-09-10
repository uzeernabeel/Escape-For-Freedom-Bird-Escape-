using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public static UIScript Instance { get; private set; }

    // Use this for initialization
    void Start() {
        Instance = this;
    }

    [SerializeField]
    private Text pointsTxt;

    public void GetPoint() {
        ManagerScript.Instance.IncrementCounter();
    }

    public void Restart() {
        ManagerScript.Instance.RestartGame();
    }

    public void Unlock() {
        PlayGamesScript.UnlockAchievement(GPGSIds.achievement_buy_the_eagle);
    }

    public void ShowAchievements() {
        PlayGamesScript.ShowAchievementsUI();
    }

    public void ShowLeaderboards() {
        PlayGamesScript.ShowLeaderboardsUI();
    }

    public void UpdatePointsText() {
        //pointsTxt.text = ManagerScript.Counter.ToString();
    }

}