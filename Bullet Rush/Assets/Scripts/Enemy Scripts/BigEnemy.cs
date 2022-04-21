using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigEnemy : Enemy
{

    public Transform frontOfPlayer;
    public Transform backOfPlayer;

    private bool isAtBehind;

    void Start()
    {
        isAtBehind = false;
        enemyAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        float distance = (player.position - transform.position).magnitude;

        if (distance <= distanceLimit)
        {

            float distanceWithFront = (transform.position - frontOfPlayer.position).magnitude;
            float distanceWithBack = (transform.position - backOfPlayer.position).magnitude;

            if (distanceWithBack < distanceWithFront)
            {
                isAtBehind = true;
            }

            if(isAtBehind == true)  // If Enemy is closer to Player's back, it attacks
            {
                enemyAgent.SetDestination(player.position);
            }
            else         // If Enemy is closer to Player's front, it moves to player's behind
            {
                Vector3 offsett = new Vector3(0, 0, -7);
                enemyAgent.SetDestination(player.position + offsett);
            }
        }
    }
}
