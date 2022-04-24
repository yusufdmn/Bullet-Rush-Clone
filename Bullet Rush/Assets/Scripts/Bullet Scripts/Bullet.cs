using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int powerOfBullet;
    public int speedOfBullet;
    public string bulletTag;

    public Rigidbody rigidbodyOfBullet;

    public Vector3 bulletTargetPosition;


    void Start()
    {
        Invoke("InActivateBullet", 2);      // If it doesn't hit enemy
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().GotDamage(powerOfBullet);
            gameObject.SetActive(false);
        }
    }

    public void ThrowBullet(Vector3 enemyPosition)
    {
        bulletTargetPosition = enemyPosition - gameObject.transform.position;
        rigidbodyOfBullet.velocity = Vector3.zero;
        rigidbodyOfBullet.AddForce(bulletTargetPosition * speedOfBullet * Time.deltaTime);
    }
    

    private void InActivateBullet()
    {
        gameObject.SetActive(false);
    }
}