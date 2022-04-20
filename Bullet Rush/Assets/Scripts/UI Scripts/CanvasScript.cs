using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject retryPanel;
    public GameObject joystickCanvas;

    public Image progressBar;
    public Text enemyLeftText;

    private int totalEnemyAmount;
    public int enemyLeft;

    private int killedEnemy;

    void Start()
    {
        Time.timeScale = 1;

        enemyLeftText = GameObject.Find("Enemy Left Text").GetComponent<Text>();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        totalEnemyAmount = enemies.Length;
        enemyLeft = totalEnemyAmount;
        enemyLeftText.text = "Enemy Left: " + totalEnemyAmount;

        progressBar.fillAmount = 0;
        killedEnemy = 0;
    }

    public void UpdateEnemyNumber()
    {
        killedEnemy++;
        float fillAmount = ((float)killedEnemy / (float)totalEnemyAmount);
        progressBar.fillAmount = fillAmount;

        enemyLeft--;
        enemyLeftText.text = "Enemy Left: " + enemyLeft;
      
        if(enemyLeft <= 0)
        {
            Won();
        }
    }

    public void Won()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
        joystickCanvas.SetActive(false);
    }
    public void Lost()
    {
        Time.timeScale = 0;
        retryPanel.SetActive(true);
        joystickCanvas.SetActive(false);
    }


    public void RetryButton()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevelButton()
    {
        SceneManager.LoadScene(0);
    }
}