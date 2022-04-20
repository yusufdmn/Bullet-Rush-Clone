using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{

    public NavMeshAgent enemyAgent;
    public Transform player;

    public float distanceLimit;


    void Update()
    {
        float distance = (player.position - transform.position).magnitude;

        if(distance <= distanceLimit)
        {
            enemyAgent.SetDestination(player.position);
        }
    }
}
