using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private int level;
    private int littleEnemyAmount;
    private int bigEnemyAmount;

    [SerializeField] private float littEnemyPositionY;
    [SerializeField] private float bigEnemyPositionY;

    [SerializeField] Transform[] spawnSpots;
    
    void Start()
    {
        littleEnemyAmount = LevelManager.Instance.littleEnemyAmunt;
        bigEnemyAmount = LevelManager.Instance.bigEnemyAmunt;
        Debug.Log(littleEnemyAmount + "   " + bigEnemyAmount);

        SpawnEnemies(littleEnemyAmount, bigEnemyAmount);
    }


    private Vector3 GenerateRandomSpawnPosition()
    {
        Vector3 spawnPosition;
        
        int indexOfSpawnSpot = Random.Range(0, spawnSpots.Length);
        spawnPosition = spawnSpots[indexOfSpawnSpot].position;

        ChangeSpawnSpotposition(spawnSpots[indexOfSpawnSpot]);

        return spawnPosition;
    }

    private void SpawnEnemies(int littleEnemyAmount, int bigEnemyAmount)
    {

        for (int i = 0; i < littleEnemyAmount; i++)         //Spawn Little Enemies
        {
            Vector3 spawnPosition = GenerateRandomSpawnPosition();
            spawnPosition.y = littEnemyPositionY;

            string littleEnemyTag = "LittleE";
            GameObject spannedLittleEnemy = PoolManager.Instance.SpawnBulletFromPool(littleEnemyTag, spawnPosition, Quaternion.identity);
            spannedLittleEnemy.SetActive(true);
        }


        for (int i = 0; i < bigEnemyAmount; i++)         //Spawn Big Enemies
        {
            Vector3 spawnPosition = GenerateRandomSpawnPosition();
            spawnPosition.y = bigEnemyPositionY;

            string bigEnemyTag = "BigE";
            GameObject spannedBigEnemy = PoolManager.Instance.SpawnBulletFromPool(bigEnemyTag, spawnPosition, Quaternion.identity);
            spannedBigEnemy.SetActive(true);
        }

    }

    private void ChangeSpawnSpotposition(Transform spawnSpot)
    {
        int randomNumber = Random.Range(0, 2);

        Vector3 newPosOfSpawnSpot;
        if (randomNumber == 0)
        {
            newPosOfSpawnSpot = new Vector3(
                spawnSpot.transform.position.x + 1.5f,
                spawnSpot.transform.position.y,
                spawnSpot.transform.position.z);
        }
        else
        {
            newPosOfSpawnSpot = new Vector3(
                spawnSpot.transform.position.x,
                spawnSpot.transform.position.y,
                spawnSpot.transform.position.z + 1.5f);
        }

        spawnSpot.transform.position = newPosOfSpawnSpot;
    }


}
