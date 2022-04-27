using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public int health;
    
    public NavMeshAgent enemyAgent;
    public Transform player;

    public float distanceLimit;

    public static bool isPaused;

    public Animator enemyAnimator;

    public void GotDamage(int damage)
    {
        this.health -= damage;
        if (health <= 0)  
        {
            GameManager.Instance.EnemyDied();
            EnemySpawner.Instance.enemies.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    public float CalculateDistance()
    {
        float distance = (player.position - transform.position).magnitude;

        if(distance > distanceLimit)        // If it's far to Player, it doesn't move so attack animation will stop
            ChangeEnemyAnimation(false);

        return distance;
    }

    public void AttackToPlayerDirectly()
    {
        ChangeEnemyAnimation(true);
        enemyAgent.SetDestination(player.position);
    }


    public static void StopAttackGamePaused()
    {
        isPaused = true;
    }
    public static void ContinueAttack()
    {
        isPaused = false;
    }


    public void LookAtPlayer()
    {
        transform.LookAt(player.transform);
    }


    public void DefineAnimator()
    {
        enemyAnimator = gameObject.GetComponent<Animator>();
    }

    public void ChangeEnemyAnimation(bool isAttacking)
    {
        enemyAnimator.SetBool("isAttacking", isAttacking);
    }
}
