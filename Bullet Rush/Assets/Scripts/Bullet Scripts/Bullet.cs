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
        Destroy(gameObject, 4);        // If it doesn't hit enemy
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log(45645);
            other.GetComponent<Enemy>().GotDamage(powerOfBullet);  
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