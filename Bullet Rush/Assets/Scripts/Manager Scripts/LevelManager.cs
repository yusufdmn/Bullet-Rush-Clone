using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private static LevelManager _instance;  
    public static LevelManager Instance { get { return _instance; } }




    [SerializeField] Level[] levels;
    public Level currentLevel;

    public int levelNumber;
    public int littleEnemyAmunt;
    public int bigEnemyAmunt;


    private void Awake()
    {
        if (_instance != null && _instance != this)     // ******Definition of SÝngleton********
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;      // ******Definition of SÝngleton********
        }



        levelNumber = PlayerPrefs.GetInt("level", 0);

        currentLevel = levels[levelNumber];

        littleEnemyAmunt = currentLevel.littleEnemyAmount;
        bigEnemyAmunt = currentLevel.bigEnemyAmount;

    }                                      



    public void IncreaseLevel()
    {
        levelNumber++;
        PlayerPrefs.SetInt("level", levelNumber);
    }
}
