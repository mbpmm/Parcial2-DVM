using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public List<GameObject> collectableList;
    public GameObject collectable;
    public int cantCollectables;
    public Vector3 pos;
    public int maxX = 19;
    public int maxZ = 38;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cantCollectables; i++)
        {
            CreateCollectable();
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
