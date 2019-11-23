using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    Transform player;
    public GameObject enemy1;
    public GameObject enemy2;
    public Vector3 spawnValues;
    public float spawnValueX;
    public float spawnValueZ;
    public int enemies;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float timer;
    public int waves;
    private Coroutine spawn;
    private float offset=5f;
    void Start()
    {
        player = GameManager.Get().playerGO.transform;
        spawn=StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (waves >= 0)
        {
            for (int i = 0; i < enemies; i++)
            {
                spawnValueX = Random.Range(-spawnValues.x, spawnValues.x);
                spawnValueZ = Random.Range(-spawnValues.z, spawnValues.z);

                while ((spawnValueX<player.position.x-offset && spawnValueX < player.position.x + offset) || (spawnValueZ > player.position.z - offset && spawnValueZ < player.position.z + offset))
                {
                    spawnValueX = Random.Range(-spawnValues.x, spawnValues.x);
                    spawnValueZ = Random.Range(-spawnValues.z, spawnValues.z);
                }

                Vector3 spawnPosition = new Vector3(spawnValueX, spawnValues.y, spawnValueZ);
                Quaternion spawnRotation = Quaternion.identity;
                if (waves%2==0)
                {
                    GameObject b = ObjectPool.instance.GetPooledObject("Vampire");
                    b.transform.position = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), -1.3f, Random.Range(-spawnValues.z, spawnValues.z));
                }
                else
                {
                    GameObject b = ObjectPool.instance.GetPooledObject("Zombie");
                    b.transform.position = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), -1.3f, Random.Range(-spawnValues.z, spawnValues.z));
                }
                
                yield return new WaitForSeconds(spawnWait);
            }
            waves--;
            yield return new WaitForSeconds(waveWait);
        }
    }


}