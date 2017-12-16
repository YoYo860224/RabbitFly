using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiInStory : MonoBehaviour {

    public GameObject LoadingPanel;
    public GameObject fadeInPanel;

    public string Scenename_Menu;
    public string Scenename_stage1;
    public string Scenename_stage2;
    public string Scenename_stage3;
    public string Scenename_stage4;

    [Header("stageImage")]
    public Image stage1;
    public Image stage2;
    public Image stage3;
    public Image stage4;

    // Use this for initialization
    void Start () {
        fadeInPanel.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BackToMenu()
    {
        
        Invoke("OpenMenu", 0.3f);
    }

    public void OpenStage(int x)
    {
        LoadingPanel.SetActive(true);

        switch (x)
        {
            case 1:
                Invoke("OpenStage1", 1.0f);
                break;
            case 2:
                Invoke("OpenStage2", 1.0f);
                break;
            case 3:
                Invoke("OpenStage3", 1.0f);
                break;
            case 4:
                Invoke("OpenStage4", 1.0f);
                break;
        }
    }

    public void checkStage(int key)
    {
        if (key == 2)
        {
            stage1.enabled = false;
        }
        else if (key == 3)
        {
            stage2.enabled = false;
        }
        else if (key == 4)
        {
            stage3.enabled = false;
        }
    }

    private void OpenMenu()
    {
        SceneManager.LoadSceneAsync(Scenename_Menu);
    }
    private void OpenStage1()
    {
        SceneManager.LoadSceneAsync(Scenename_stage1);
    }
    private void OpenStage2()
    {
        SceneManager.LoadSceneAsync(Scenename_stage2);
    }
    private void OpenStage3()
    {
        SceneManager.LoadSceneAsync(Scenename_stage3);
    }
    private void OpenStage4()
    {
        SceneManager.LoadSceneAsync(Scenename_stage4);
    }
}
