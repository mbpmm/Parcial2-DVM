using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerController player;
    public EnemySpawner es;
    public Text pointsText;
    public Text wavesText;
    public Text ammoText;
    public Text hpText;
    public GameObject deathscreen;
    public GameObject deathscreenPC;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "Points: " + GameManager.Get().score;
        wavesText.text = "Waves: " + es.waves;
        ammoText.text = "Ammo: " + player.ammo;
        hpText.text = "HP: " + player.HP;

        if (player.isDead)
        {
#if UNITY_ANDROID 
        deathscreen.SetActive(true);  
#endif
#if UNITY_STANDALONE
        deathscreenPC.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
#endif

            Time.timeScale = 0;
            player.HP = 100;
            player.isDead = false;
        }
    }

    public void GiveLife()
    {
#if UNITY_ANDROID
        deathscreen.SetActive(false);
#endif
#if UNITY_STANDALONE
        deathscreenPC.SetActive(false);
        
#endif
        
    }
}
