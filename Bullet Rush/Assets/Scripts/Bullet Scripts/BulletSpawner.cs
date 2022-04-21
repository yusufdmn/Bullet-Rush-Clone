using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;

    private float bulletSpawnTimerLimit;
    private float bulletSpawnTimer;

    private float distanceLimitWithEnemy;     // To spawn bullet when enemies are close enough
    private bool shouldSpawn;
    
    private static bool isGameOver;

    private Vector3 closestEnemyPos;

    void Start()
    {
        isGameOver = false;
        shouldSpawn = false;
        bulletSpawnTimerLimit = 0.5f;
        distanceLimitWithEnemy = 10f;
    }


    void Update()
    {

        if(isGameOver == false)
        {
            bulletSpawnTimer += Time.deltaTime;

            if (bulletSpawnTimer > bulletSpawnTimerLimit)
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                closestEnemyPos = DetectClosestEnemy(enemies);

                shouldSpawn = DetectIfEnemyCloseEnough(closestEnemyPos);
            }


            if (shouldSpawn == true)
            {
                Debug.Log(closestEnemyPos);
                InstantiateBullet(closestEnemyPos);
                shouldSpawn = false;
                bulletSpawnTimer = 0;
            }
        }
    }


    public Vector3 DetectClosestEnemy(GameObject[] enemies)
    {
        Vector3 closestEnemyPos = enemies[0].transform.position;
        float closestDistance = (closestEnemyPos - gameObject.transform.position).magnitude;

        for (int i = 0; i < enemies.Length; i++)
        {
            float distanceWithPlayer = (gameObject.transform.position - enemies[i].transform.position).magnitude;

            if(distanceWithPlayer < closestDistance)
            {
                closestDistance = distanceWithPlayer;
                closestEnemyPos = enemies[i].transform.position;
            }
        }

        return closestEnemyPos;
    }


    public void InstantiateBullet(Vector3 target)
    {
        GameObject newbullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        newbullet.GetComponent<Bullet>().ThrowBullet(target);
    }


    public bool DetectIfEnemyCloseEnough(Vector3 closerEnemyPosition){
        if (Vector3.Magnitude(closerEnemyPosition - gameObject.transform.position) <= distanceLimitWithEnemy) {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void StopSpawnBullet()
    {
        isGameOver = true;
    }
}
