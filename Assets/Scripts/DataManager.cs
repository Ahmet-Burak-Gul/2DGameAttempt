using System;
using System.Collections;
using System.Collections.Generic;
using TigerForge;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private int shotSton;
    public int totalShotSton;
    private int enemyKilled;
    public int totalEnemyKilled;

    EasyFileSave myFile;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }        
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        ShotSton = 0;
        EnemyKilled = 0;
    }

    public int ShotSton
    {
        get 
        {
            return shotSton;
        }
        set 
        {
            shotSton = value;
            GameObject.Find("ShotStonText").GetComponent<Text>().text = "Shot Ston: " + shotSton.ToString();
        }
    }

    public int EnemyKilled
    {
        get
        {
            return enemyKilled;
        }
        set
        {
            enemyKilled = value;
            GameObject.Find("EnemyKilledText").GetComponent<Text>().text = "Enemy Killed: " + enemyKilled.ToString();
        }
    }

    void StartProcess()
    {
        myFile = new EasyFileSave();
        LoadData();
    }

    public void SaveData()
    {
        totalShotSton += shotSton;
        totalEnemyKilled += enemyKilled;

        myFile.Add("totalShotSton", totalShotSton);
        myFile.Add("totalEnemyKilled", totalEnemyKilled);

        myFile.Save();
    }

    public void LoadData()
    {
        Console.WriteLine(myFile.Load());
        if (myFile.Load())
        {
            totalShotSton = myFile.GetInt("totalShotSton");
            totalEnemyKilled = myFile.GetInt("totalEnemyKilled");
        }
    }
}
