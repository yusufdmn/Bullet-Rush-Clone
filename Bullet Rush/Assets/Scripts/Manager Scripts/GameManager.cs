using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public UnityEvent winEvent;
    public UnityEvent loseEvent;

    public int totalEnemyAmount;
    public int enemyLeft;

    public bool isGameOver;
    public bool isPaused;

    private static GameManager _instance;       // ******Definition of Singleton********
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
    }                                            // ******Definition of Singleton********


    private void Start()
    {
        winEvent.AddListener(PlayerWon);
        loseEvent.AddListener(PlayerLost);

        isGameOver = false;
        ArrayList enemies = EnemySpawner.Instance.enemies;

        totalEnemyAmount = enemies.Count;
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
            winEvent.Invoke();
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
    public void PauseGame()
    {
        Player.StopMoveGamePaused();
        BulletSpawner.StopSpawnBulletGamePaused();
        Enemy.StopAttackGamePaused();
    }
    public void ContinueGame()
    {
        Player.ContinueMove();
        BulletSpawner.ContinueSpawnBulletGamePaused();
        Enemy.ContinueAttack();
    }


    public void PlayerWon()
    {
        LevelManager.Instance.IncreaseLevel();
        isGameOver = true;
        CanvasManager.Instance.ActivateWinPanel();
        BulletSpawner.StopSpawnBulletGameOver();
        Player.StopMoveGameOver();
    }

    public void PlayerLost()
    {
        isGameOver = true;
        CanvasManager.Instance.ActivateLostPanel();
        BulletSpawner.StopSpawnBulletGameOver();
        Player.StopMoveGameOver();
    }
}
