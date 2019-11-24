using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonobehaviourSingleton<GameManager>
{
    public int score;
    public GameObject playerGO;
    public PlayerController playerScript;
    public GameObject getlifeButton;
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID
        GPSManager.Get().SignIn();
#endif
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerScript = playerGO.GetComponentInChildren<PlayerController>();
    }
    private void Update()
    {
        
    }

    public void AddScore()
    {
        score+=100;

#if UNITY_ANDROID
        if (score == 1000)
        {
            GPSManager.Get().UnlockAchievement1000();
        }

        if (score == 2000)
        {
            GPSManager.Get().UnlockAchievement2000();
        }
#endif
    }

    public void GetReward()
    {
        Time.timeScale = 1;
    }

    public void WatchAd()
    {
        AdsManager.Get().UIWatchRewardedAd();
    }

    public void Retry()
    {
        SceneManager.LoadScene("Bombo");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }


}
