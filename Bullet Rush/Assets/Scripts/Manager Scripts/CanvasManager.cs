using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject pausePanel;
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


    public void UpdateEnemyTextAndProgressBar(int totalEnemy, int enemyLeft)
    {
        enemyLeftText.text = "Enemy Left: " + enemyLeft;

        int killedEnemy = totalEnemy - enemyLeft;      
        float fillAmount = ((float)killedEnemy / (float)totalEnemy);
        progressBar.fillAmount = fillAmount;
    }



    public void ActivateWinPanel()
    {
        winPanel.SetActive(true);
    }

    public void ActivateLostPanel()
    {
        retryPanel.SetActive(true);
    }

    public void ActivateOrDeactivatePausePanel()
    {
        bool isPaused = pausePanel.activeSelf;
        pausePanel.SetActive(!isPaused);
    }


    public void RetryButton()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(0);
    }
    public void PauseButton()
    {
        ActivateOrDeactivatePausePanel();
        GameManager.Instance.PauseGame();
    }
    public void ContinueButton()
    {
        GameManager.Instance.ContinueGame();
        ActivateOrDeactivatePausePanel();
    }

}