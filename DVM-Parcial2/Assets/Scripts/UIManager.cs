using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public EnemySpawner es;
    public Text pointsText;
    public Text wavesText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "Points: " + GameManager.Get().score;
        wavesText.text = "Waves: " + es.waves;
    }
}
