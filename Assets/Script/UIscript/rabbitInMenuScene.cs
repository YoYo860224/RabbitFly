using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class rabbitInMenuScene : MonoBehaviour {

    public Image one;
    public Image two;
    public Image three;
    public Image four;
    public Image five;
    public Image six;
    public Text byeText;

    public GameObject quitPanel;

    public GameObject changeChoosePanel;
    public GameObject arrowPanel;
    public GameObject storyCarrot;
    public GameObject pKCarrot;
    public GameObject quitCarrot;
    // Use this for initialization
    void Start()
    {
        changeChoosePanel.SetActive(false);
        quitPanel.SetActive(false);
        arrowPanel.SetActive(true);
        one.enabled = false;
        two.enabled = false;
        three.enabled = false;
        four.enabled = false;
        five.enabled = false;
        six.enabled = false;
        byeText.enabled = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Rabbit" && gameObject.name == "storyCarrot")
        {
            this.GetComponent<Animator>().SetBool("hitCarrot", true);
            storyCarrot.GetComponent<Collider2D>().enabled = false;
            pKCarrot.GetComponent<Collider2D>().enabled = false;
            quitCarrot.GetComponent<Collider2D>().enabled = false;
            this.Invoke("changeChoose", 0.7f);
            this.Invoke("loadchoose", 2.0f);
        }

        else if (collision.gameObject.name == "Rabbit" && gameObject.name == "pkCarrot")
        {
            this.GetComponent<Animator>().SetBool("hitCarrot", true);
            storyCarrot.GetComponent<Collider2D>().enabled = false;
            pKCarrot.GetComponent<Collider2D>().enabled = false;
            quitCarrot.GetComponent<Collider2D>().enabled = false;
            this.Invoke("changeChoose", 0.7f);
            this.Invoke("loadpk", 2.0f);
        }
        else if (collision.gameObject.name == "Rabbit" && gameObject.name == "quitCarrot")
        {
            this.GetComponent<Animator>().SetBool("hitCarrot", true);
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
    }

    private void loadchoose()
    {
        SceneManager.LoadSceneAsync("chooseScene");
    }//load choose stage scene
    private void changeChoose()
    {
        changeChoosePanel.SetActive(true);
    }//load change scenePanel
    private void loadquitPanel()
    {//quitPanel set active
        quitPanel.SetActive(true);
    }
    private void loadpk()
    {
        SceneManager.LoadSceneAsync("PKMode");
    }//load pk scene

    private void quitGame()
    {
        Application.Quit();
    }//quit game

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
}
