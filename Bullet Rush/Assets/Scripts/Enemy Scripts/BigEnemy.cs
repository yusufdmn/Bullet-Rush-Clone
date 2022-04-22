using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigEnemy : Enemy
{

    [SerializeField] Transform frontOfPlayer;
    [SerializeField] Transform backOfPlayer;

    private bool isAtBehind;

    void Start()
    {
        isAtBehind = false;
        enemyAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        float distance = CalculateDistance();

        if (distance <= distanceLimit)
        {

            float distanceWithFront = (transform.position - frontOfPlayer.position).magnitude;
            float distanceWithBack = (transform.position - backOfPlayer.position).magnitude;

            if (distanceWithBack <= distanceWithFront)
            {
                isAtBehind = true;
            }

            if(isAtBehind == true)  // If Enemy is closer to Player's back, it attacks
            {
                Debug.Log(15643);
                AttackToPlayerDirectly();
            }
            else         // If Enemy is closer to Player's front, it moves to player's behind
            {
                MoveToPlayersBack();
            }
        }
    }

    private void MoveToPlayersBack()
    {
        Vector3 offsett = new Vector3(0, 0, -7);
        enemyAgent.SetDestination(player.position + offsett);
    }


}
