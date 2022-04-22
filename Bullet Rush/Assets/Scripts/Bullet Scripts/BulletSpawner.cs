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

    private string currentBulletType;

    void Start()
    {
        currentBulletType = "Bullet1";

        isGameOver = false;
        shouldSpawn = false;
        bulletSpawnTimerLimit = 0.3f;
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
                SpawnBullet(closestEnemyPos);
                shouldSpawn = false;
                bulletSpawnTimer = 0;
            }
        }
    }


    private Vector3 DetectClosestEnemy(GameObject[] enemies)
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

    private void SpawnBullet( Vector3 target)
    {
        GameObject spannedBullet = BulletPool.Instance.SpawnBulletFromPool(currentBulletType, transform.position, Quaternion.identity);
        spannedBullet.SetActive(true);
        spannedBullet.GetComponent<Bullet>().ThrowBullet(target);
    }

    private bool DetectIfEnemyCloseEnough(Vector3 closerEnemyPosition){
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
