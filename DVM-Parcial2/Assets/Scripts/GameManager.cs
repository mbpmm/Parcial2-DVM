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
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerScript = playerGO.GetComponentInChildren<PlayerController>();
    }
    private void Update()
    {
        if (score==1000)
        {
            GPSManager.Get().UnlockAchievementId("CgkIz76O5PUKEAIQAQ");
        }

        if (score == 2000)
        {
            GPSManager.Get().UnlockAchievementId("CgkIz76O5PUKEAIQAg");
        }
    }

    public void AddScore()
    {
        score+=100;
    }

    public void GetReward()
    {
        getlifeButton.SetActive(true);
    }
}
