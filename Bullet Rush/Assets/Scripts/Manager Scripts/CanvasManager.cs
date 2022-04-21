using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{


    public GameObject winPanel;
    public GameObject retryPanel;
    public GameObject joystickCanvas;

    public Image progressBar; 
    public Text enemyLeftText;


    private static CanvasManager _instance;     // ******Definition of SÝngleton********
    public static CanvasManager Instance { get { return _instance; } }
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
    }                                           // ******Definition of SÝngleton********


    private void Start()
    {
        int totalEnemy = GameManager.Instance.totalEnemyAmount;
        enemyLeftText.text = "Enemy Left: " + totalEnemy;
    }


    public void UpdateEnemyText()
    {
        int enemyleft = GameManager.Instance.enemyLeft;
        enemyLeftText.text = "Enemy Left: " + enemyleft;
    }


    public void UpdateProgressBar()
    {
        int totalEnemy = GameManager.Instance.totalEnemyAmount;
        int enemyLeft = GameManager.Instance.enemyLeft;

        int killedEnemy = totalEnemy - enemyLeft;
        
        float fillAmount = ((float)killedEnemy / (float)totalEnemy);
        progressBar.fillAmount = fillAmount;
    }



    public void ActivateWinPanel()
    {
        winPanel.SetActive(true);
        joystickCanvas.SetActive(false);
    }

    public void ActivateLostPanel()
    {
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