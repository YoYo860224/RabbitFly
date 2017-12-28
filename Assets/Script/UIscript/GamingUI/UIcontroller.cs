﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour {

    public GameObject gamePanel;
    public GameObject menuPanel;
    public GameObject fadeInPanel;

    [Header("Story")]
    public bool isStory;
    public GameObject winPanel;         // for story win
    public GameObject losePanel;        // for story lose

    [Header("Pk")]
    public bool isPk;
    public GameObject finishPanel;      // for PK finish

    [Header("Timer")]
    public Text timerText;
    private float timer = 0;

    [Header("Combo")]
    public Text comboText;
    public float comboShowTime = 1.0f;

    [Header("Life")]
    public Image blood1;
    public Image blood2;
    public Image blood3;

    [Header("Music")]
    public GameObject scrollM;
    public GameObject scrollS;

    public static UIcontroller UIcontroll;

    void Start()
    {
        UIcontroll = this;

        fadeInPanel.SetActive(true);
        gamePanel.SetActive(true);
        comboText.enabled = false;
        menuPanel.SetActive(false);
        if (isStory)
        {
            winPanel.SetActive(false);
            losePanel.SetActive(false);
        }

        if (isPk)
        {
            finishPanel.SetActive(false);
        }

        scrollM.GetComponent<Scrollbar>().value = PlayerPrefs.GetFloat("music_value");
        scrollS.GetComponent<Scrollbar>().value = PlayerPrefs.GetFloat("sound_value");
    }

    void Update()  
    {
        if (timerText)
        {
            timer += Time.deltaTime;
            timerText.text = " timer : " + ((int)timer).ToString();
        }
    }
    public void restart()       // 重 load 這一關
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1f;
    }

    public void resume()        // 關閉 menu 遊戲繼續
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void quitStage()
    {
        SceneManager.LoadScene("storyScene");
        Time.timeScale = 1f;
    }

    public void quitPkStage()
    {
        SceneManager.LoadScene("menuScene");
        Time.timeScale = 1f;
    }

    public void openMenu()      // 打開 menu遊戲暫停
    {        
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void openWin()
    {
        winPanel.SetActive(true);
        if (blood3.IsActive())
        {
            winPanel.transform.Find("star3").gameObject.active = true;
        }
        else if (blood2.IsActive())
        {
            winPanel.transform.Find("star2").gameObject.active = true;
        }
        else if (blood1.IsActive())
        {
            winPanel.transform.Find("star1").gameObject.active = true;
        }
        Time.timeScale = 1f;
    }

    public void openLose()
    {
        losePanel.SetActive(true);
        Time.timeScale = 1f;
    }

    public void openFinish()
    {
        finishPanel.SetActive(true);
        Time.timeScale = 1f;
    }

    public void delayDo(string func, float t)
    {
        Invoke(func, t);
    }

    public void lifeMinus(int nowLife) {
        if (nowLife == 2)
        {
            blood3.enabled = false;
        }
        else if (nowLife == 1)
        {
            blood2.enabled = false;
        }
        else if(nowLife == 0)
        {
            blood1.enabled = false;
            Time.timeScale = 0.5f;
            delayDo("openLose", 0.5f);
        }
    }

    public void SetCombo(int conbo_in)
    {
        CancelInvoke("ComboDisappear");
        comboText.enabled = true;
        comboText.text = conbo_in.ToString() + " Combo !!!!";
        Invoke("ComboDisappear", comboShowTime);
    }

    public void ComboDisappear()
    {
        comboText.enabled = false;
    }


    public void OpenStage(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void SetMusic(float v)
    {
        PlayerPrefs.SetFloat("music_value", v);
        Camera.main.GetComponent<TheSetting>().allSetUpdate();
    }

    public void SetSound(float v)
    {
        PlayerPrefs.SetFloat("sound_value", v);
        Camera.main.GetComponent<TheSetting>().allSetUpdate();
    }

    public void SetRecord(int v)
    {
        PlayerPrefs.SetInt("record", v);
        Camera.main.GetComponent<TheSetting>().allSetUpdate();
    }
}
