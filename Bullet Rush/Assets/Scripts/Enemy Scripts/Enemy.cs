using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;

    public bool GotDamage(int damage)
    {
        this.health -= damage;

        if(health <= 0)      // It will return true if the enemy is dead
        {
            return true;
        }
        else                // It will return false if the enemy is still alive
        {
            return false;
        }
    }

}
