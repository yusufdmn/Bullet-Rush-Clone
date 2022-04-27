using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LittleEnemy : Enemy
{

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        enemyAgent = gameObject.GetComponent<NavMeshAgent>();
    }
   

    void Update()
    {
        if (isPaused == true)
        {
            enemyAgent.speed = 0;
        }
        else
        {
            enemyAgent.speed = 10;
        }

        float distance = CalculateDistance();



        if (isPaused == false && distance <= distanceLimit)
        {
            AttackToPlayerDirectly();
        }
    }
}