using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiInMenu : MonoBehaviour
{

    [Header("for quit scene")]
    public GameObject quitPanel;
    public Image one;
    public Image two;
    public Image three;
    public Image four;
    public Image five;
    public Image six;
    public Text byeText;

    [Header("SceneManager")]
    public string SceneName_Story;
    public string SceneName_Pk;

    [Header("PanelManager")]
    public GameObject fadeInPanel;
    public GameObject LoadingPanel;
    public GameObject arrowPanel;

    [Header("Carrot")]
    public GameObject storyCarrot;
    public GameObject pKCarrot;
    public GameObject quitCarrot;
    // Use this for initialization
    void Start()
    {
        fadeInPanel.SetActive(true);
        arrowPanel.SetActive(true);
        LoadingPanel.SetActive(false);

        quitPanel.SetActive(false);
        one.enabled = false;
        two.enabled = false;
        three.enabled = false;
        four.enabled = false;
        five.enabled = false;
        six.enabled = false;
        byeText.enabled = false;
    }

    public void DoStroyCarrot()
    {
        storyCarrot.GetComponent<Animator>().SetBool("hitCarrot", true);
        storyCarrot.GetComponent<Collider2D>().enabled = false;
        pKCarrot.GetComponent<Collider2D>().enabled = false;
        quitCarrot.GetComponent<Collider2D>().enabled = false;
        this.Invoke("changeChoose", 0.7f);
        this.Invoke("loadchoose", 2.0f);
    }

    public void DoPkCarrot()
    {
        pKCarrot.GetComponent<Animator>().SetBool("hitCarrot", true);
        storyCarrot.GetComponent<Collider2D>().enabled = false;
        pKCarrot.GetComponent<Collider2D>().enabled = false;
        quitCarrot.GetComponent<Collider2D>().enabled = false;
        this.Invoke("changeChoose", 0.7f);
        this.Invoke("loadpk", 2.0f);
    }

    public void DoQuitCarrot()
    {
        quitCarrot.GetComponent<Animator>().SetBool("hitCarrot", true);
        storyCarrot.GetComponent<Collider2D>().enabled = false;
        pKCarrot.GetComponent<Collider2D>().enabled = false;
        quitCarrot.GetComponent<Collider2D>().enabled = false;
        this.Invoke("loadquitPanel", 0.7f);
        this.Invoke("oneTO", 1.0f);
        this.Invoke("destroy1", 1.2f);
        this.Invoke("oneTOtwo", 1.2f);
        this.Invoke("destroy2", 1.4f);
        this.Invoke("twoTOthree", 1.4f);
        this.Invoke("destroy3", 1.6f);
        this.Invoke("threeTOfour", 1.6f);
        this.Invoke("destroy4", 1.8f);
        this.Invoke("fourTOfive", 1.8f);
        this.Invoke("destroy5", 2.0f);
        this.Invoke("fiveTOsix", 2.0f);
        this.Invoke("byeTextappear", 2.0f);
        this.Invoke("quitGame", 3.0f);
    }

    //load choose stage scene
    private void changeChoose()
    {
        LoadingPanel.SetActive(true);
    }

    private void loadchoose()
    {
        SceneManager.LoadSceneAsync(SceneName_Story);
    }

    private void loadpk()
    {
        SceneManager.LoadSceneAsync(SceneName_Pk);
    }

    private void quitGame()
    {
        Application.Quit();
    }

    #region QuitPanel

    private void loadquitPanel()
    {
        quitPanel.SetActive(true);
    }

    //quitPanel image apper 
    private void oneTO()
    {
        one.enabled = true;
    }
    private void oneTOtwo()
    {
        two.enabled = true;
    }
    private void twoTOthree()
    {
        three.enabled = true;
    }
    private void threeTOfour()
    {
        four.enabled = true;
    }
    private void fourTOfive()
    {
        five.enabled = true;
    }
    private void fiveTOsix()
    {
        six.enabled = true;
    }

    //quitPanel image disapper
    private void destroy1()
    {
        one.enabled = false;
    }
    private void destroy2()
    {
        two.enabled = false;
    }
    private void destroy3()
    {
        three.enabled = false;
    }
    private void destroy4()
    {
        four.enabled = false;
    }
    private void destroy5()
    {
        five.enabled = false;
    }

    //quitPanel byeText appear
    private void byeTextappear()
    {
        byeText.enabled = true;
        byeText.text = "B Y E      B Y E";
    }
    #endregion
}
