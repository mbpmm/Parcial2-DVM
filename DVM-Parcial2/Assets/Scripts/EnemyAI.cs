using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Awake()
    {
        agent=GetComponent<NavMeshAgent>();
        player = GameManager.Get().playerGO.transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            gameObject.SetActive(false);
            GameManager.Get().AddScore();
        }
    }
}
