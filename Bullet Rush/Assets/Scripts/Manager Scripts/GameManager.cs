using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalEnemyAmount;
    public int enemyLeft;

    public bool isGameOver;


    private static GameManager _instance;       // ******Definition of SÝngleton********
    public static GameManager Instance { get { return _instance; } }
    private void Awake() 
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }                                            // ******Definition of SÝngleton********


    private void Start()
    {
        isGameOver = false;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        totalEnemyAmount = LevelManager.Instance.littleEnemyAmunt + LevelManager.Instance.bigEnemyAmunt;
        enemyLeft = totalEnemyAmount;

        CanvasManager.Instance.UpdateEnemyTextAndProgressBar(totalEnemyAmount, enemyLeft);
    }
    

    public void EnemyDied()
    {
        enemyLeft--;
        CanvasManager.Instance.UpdateEnemyTextAndProgressBar(totalEnemyAmount, enemyLeft);

        bool isPlayerWon = ControlIfPlayerWon();

        if(isPlayerWon == true)
        {
            Playerwon();
        }
    }

    public bool ControlIfPlayerWon()
    {
        if(enemyLeft <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Playerwon()
    {
        LevelManager.Instance.IncreaseLevel();
        isGameOver = true;
        CanvasManager.Instance.ActivateWinPanel();
        BulletSpawner.StopSpawnBullet();
        Player.StopMove();
    }

    public void PlayerLost()
    {
        isGameOver = true;
        CanvasManager.Instance.ActivateLostPanel();
        BulletSpawner.StopSpawnBullet();
        Player.StopMove();
    }
}
