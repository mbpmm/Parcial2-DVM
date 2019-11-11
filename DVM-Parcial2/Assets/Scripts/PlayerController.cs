using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletEmitter;
    public float nextFire;
    public float fireRate;

    public LayerMask rayCastLayer;
    public float rayDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.left * 20, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, rayCastLayer))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);

            string layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            switch (layerHitted)
            {
                case "Enemies":
                    if (Time.time > nextFire)
                    {
                        nextFire = Time.time + fireRate;
                        Shoot();
                    }
                    break;
            }

        }
        
    }

    public void Shoot()
    {
        GameObject b = ObjectPool.instance.GetPooledObject("Bullet");
        b.transform.position = bulletEmitter.transform.position;
        b.transform.rotation = bulletEmitter.transform.rotation;
    }
}
