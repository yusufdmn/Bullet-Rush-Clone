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
        return distance;
    }

    public void AttackToPlayerDirectly()
    {
        enemyAgent.SetDestination(player.position);
    }


}
