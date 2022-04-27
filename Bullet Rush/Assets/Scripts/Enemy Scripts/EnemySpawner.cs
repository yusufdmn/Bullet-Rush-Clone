using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private static EnemySpawner _instance;
    public static EnemySpawner Instance { get { return _instance; } }


    public int level;
    public int littleEnemyAmount;
    public int bigEnemyAmount;
    public ArrayList enemies = new ArrayList();


    

    [SerializeField] private float littEnemyPositionY;
    [SerializeField] private float bigEnemyPositionY;

    [SerializeField] Transform[] spawnSpots;
    
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {


        littleEnemyAmount = LevelManager.Instance.littleEnemyAmunt;
        bigEnemyAmount = LevelManager.Instance.bigEnemyAmunt;

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
            GameObject spawnedLittleEnemy = PoolManager.Instance.SpawnBulletFromPool(littleEnemyTag, spawnPosition, Quaternion.identity);
            spawnedLittleEnemy.SetActive(true);
            enemies.Add(spawnedLittleEnemy);

        }


        for (int i = 0; i < bigEnemyAmount; i++)         //Spawn Big Enemies
        {
            Vector3 spawnPosition = GenerateRandomSpawnPosition();
            spawnPosition.y = bigEnemyPositionY;

            string bigEnemyTag = "BigE";
            GameObject spawnedBigEnemy = PoolManager.Instance.SpawnBulletFromPool(bigEnemyTag, spawnPosition, Quaternion.identity);
            spawnedBigEnemy.SetActive(true);
            enemies.Add(spawnedBigEnemy);

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
