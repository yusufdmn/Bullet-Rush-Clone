using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LittleEnemy : Enemy
{

    private void Start()
    {
        enemyAgent = gameObject.GetComponent<NavMeshAgent>();
    }
   

    void Update()
    {
        float distance = (player.position - transform.position).magnitude;

        if (distance <= distanceLimit)
        {
            enemyAgent.SetDestination(player.position);
        }
    }
}