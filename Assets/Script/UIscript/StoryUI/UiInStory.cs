using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiInStory : MonoBehaviour {

    public GameObject LoadingPanel;

    public string Scenename_Menu;
    public string Scenename_stage1;
    public string Scenename_stage2;
    public string Scenename_stage3;
    public string Scenename_stage4;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BackToMenu()
    {
        LoadingPanel.SetActive(true);
        Invoke("OpenMenu", 0.3f);
    }

    public void OpenStage(int x)
    {
        LoadingPanel.SetActive(true);

        switch (x)
        {
            case 1:
                Invoke("OpenStage1", 0.3f);
                break;
            case 2:
                Invoke("OpenStage2", 0.3f);
                break;
            case 3:
                Invoke("OpenStage3", 0.3f);
                break;
            case 4:
                Invoke("OpenStage4", 0.3f);
                break;
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
