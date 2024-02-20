using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerScene : MonoBehaviour
{
    public GameObject dataBoard,dataBoardButton;
    public void Playbuton()
    {
        SceneManager.LoadScene(1);
    }

    public void DataBoardButton()
    {
        DataManager.instance.LoadData();

        dataBoard.transform.GetChild(2).GetComponent<Text>().text = DataManager.instance.totalEnemyKilled.ToString();
        dataBoard.transform.GetChild(1).GetComponent<Text>().text = DataManager.instance.totalShotSton.ToString();
        dataBoard.SetActive(true);
        dataBoardButton.SetActive(false);
    }

    public void XDataBoard()
    {
        dataBoard.SetActive(false);
        dataBoardButton.SetActive(true);
    }
}
