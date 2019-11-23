using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public int maxX = 19;
    public int maxZ = 38;
    public float timer;
    public float newSpawnTime;
    // Start is called before the first frame update
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>newSpawnTime)
        {
            CreateCollectable();
            timer = 0;
        }
    }

    public GameObject CreateCollectable()
    {
        if ((Random.Range(0,2)) == 1)
        {
            GameObject b = ObjectPool.instance.GetPooledObject("Ammo");
            b.transform.position = new Vector3(Random.Range(-maxX, maxX), -1.3f, Random.Range(-maxZ, maxZ));
            return b;
        }
        else
        {
            GameObject b2 = ObjectPool.instance.GetPooledObject("HP");
            b2.transform.position = new Vector3(Random.Range(-maxX, maxX), -1.3f, Random.Range(-maxZ, maxZ));
            return b2;
        }
        
    }
}
