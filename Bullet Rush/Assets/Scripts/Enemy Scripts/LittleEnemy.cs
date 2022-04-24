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
        float distance = CalculateDistance();

        if (distance <= distanceLimit)
        {
            AttackToPlayerDirectly();
        }
    }
}