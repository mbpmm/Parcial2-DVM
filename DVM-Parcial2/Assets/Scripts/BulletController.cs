using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public float lifeSpan;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        transform.position += transform.forward * Time.deltaTime * speed;

        if (timer >= lifeSpan)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            timer = 0;
        }

        if (other.gameObject.tag == "Vampire")
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            timer = 0;
        }
    }
}