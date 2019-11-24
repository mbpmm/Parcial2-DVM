using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VRButton : MonoBehaviour
{
    bool locked = false;
    float timer = 0f;
    float timePressed = 0.6f;
    public UIManager UIMan;
    void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => { locked = true; });
        trigger.triggers.Add(entry);

        EventTrigger.Entry exit = new EventTrigger.Entry();
        exit.eventID = EventTriggerType.PointerExit;
        exit.callback.AddListener((data) => { locked = false; });
        trigger.triggers.Add(exit);
    }

    private void OnEnable()
    {
        locked = false;
    }

    private void Update()
    {
        if (locked)
        {
            timer += Time.deltaTime;
            if (timer >= timePressed)
            {
                timer = 0;
                Pressed();
                transform.parent.gameObject.SetActive(false);
            }
        }
        else
        {
            timer = 0;
        }
    }

    void Pressed()
    {
        switch (gameObject.tag)
        {
            case "WatchAdButton":
                GameManager.Get().WatchAd();
                break;
        }
    }
}
