using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int powerOfBullet;
    [SerializeField] private int speedOfBullet;
    public Rigidbody rigidbodyOfBullet;
    private Vector3 bulletTargetPosition;

    void Start()
    {
        Destroy(gameObject, 4);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            bool isEnemyDead = other.GetComponent<Enemy>().GotDamage(powerOfBullet);   // It damages the enemy's health, keeps if its dead or alive

            if (isEnemyDead == true){
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
    }

    public void ThrowBullet(Vector3 enemyPosition)
    {
        bulletTargetPosition = enemyPosition - gameObject.transform.position;
        bulletTargetPosition.y = 0;
        rigidbodyOfBullet.AddForce(bulletTargetPosition * speedOfBullet);
    }
    
}