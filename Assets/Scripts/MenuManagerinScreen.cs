using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerinScreen : MonoBehaviour
{
    public GameObject inGameScreen,pauseScreen;

    public void PauseButton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
        
    }

    public void PlayaButton()
    {
        Time.timeScale = 1;
        inGameScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }

    public void RePlayaButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void HomeButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        DataManager.instance.SaveData();
    }
}   
