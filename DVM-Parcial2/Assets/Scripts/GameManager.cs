using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonobehaviourSingleton<GameManager>
{
    public int score;
    public GameObject playerGO;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        
    }

    public void AddScore()
    {
        score+=100;
    }
}
