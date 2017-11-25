using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour {

    public GameObject gamePanel;
    public GameObject menuPanel;
    public GameObject FinishPanel;      // for PK    (temp need bind)
    public GameObject gameOverPanel;    // for Stage (temp need bind)
    public Text timerText;
    public Image blood1;
    public Image blood2;
    public Image blood3;
    private float timer = 0;

    public static UIcontroller
    UIcontroll;

    void Start() {
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        gameOverPanel.SetActive(false);
        UIcontroll = this;
    }
    void Update() {
        timer += Time.deltaTime;
        timerText.text = " timer : " + ((int)timer).ToString();
    }
    public void restart() {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1f;
    }
    public void resume(){//關閉menu遊戲繼續
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void openMenu() {//打開menu遊戲暫停
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void openFinish()
    {
        FinishPanel.SetActive(true);
    }

    public void lifeMinus() {
        if (RabbitInfo.Instance.life == 2)
        {
            blood3.enabled = false;
        }
        else if (RabbitInfo.Instance.life == 1)
        {
            blood2.enabled = false;
        }
        else if(RabbitInfo.Instance.life == 0)
        {
            blood1.enabled = false;
            gameOverPanel.SetActive(true);
        }
    }

    public void quitStage() {
        SceneManager.LoadScene("menuScene");
        Time.timeScale = 1f;
    }
}
