using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GPSManager : MonobehaviourSingleton<GPSManager>
{


#if UNITY_ANDROID
    // Start is called before the first frame update
    void Start()
    {
        InitializeGPSF();
        SignIn();
    }

    private void InitializeGPSF()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
    }

    public void SignIn()
    {
        Social.localUser.Authenticate((bool success) => {

            if (success)
            {
                Debug.Log("Good");
            }
            else
            {
                Debug.Log("Bad");
            }
            // handle success or failure
        });
    }

    public void SignOut()
    {
        PlayGamesPlatform.Instance.SignOut();
    }

    public void UnlockAchievementId(string id)
    {
        Social.ReportProgress(id, 100.0f, (bool success) =>
        {
            Debug.Log("paso por aca");
        });
    }

    public void OpenAchievements()
    {
        Social.ShowAchievementsUI();
    }

    public void OpenLeaderboards()
    {
        Social.ShowLeaderboardUI();
    }

    public void UploadScore(int score)
    {
        Social.ReportScore(score, "CgkIhYDc8t4eEAIQAQ", (bool success) =>
        {
            if (success)
            {
                Debug.Log("log to leaderboard succeeded");
            }
            else
            {
                Debug.Log("log to leaderboard failed");
            }

            // handle success or failure
        });
    }
#endif
}
