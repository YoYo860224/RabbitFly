using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class rabbitInMenuScene : MonoBehaviour {

    public GameObject chooseStagePanel;
    public Text story;
    public Text pk;
    public Text quit;
    // Use this for initialization
    void Start()
    {
        chooseStagePanel.SetActive(false);
        story.enabled = true;
        pk.enabled = true;
        quit.enabled = true;
    }
    public void chooseStageOne()
    {
        chooseStagePanel.SetActive(false);
        SceneManager.LoadScene("TestScene");
    }
    public void chooseStageTwo()
    {
        SceneManager.LoadScene("Stage2");
        chooseStagePanel.SetActive(false);
    }
    public void chooseStageThree()
    {
        SceneManager.LoadScene("Stage3");
        chooseStagePanel.SetActive(false);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Rabbit" && gameObject.name == "storyCarrot")
        {
            chooseStagePanel.SetActive(true);
            story.enabled = false;
        }

        else if (collision.gameObject.name == "Rabbit" && gameObject.name == "pkCarrot")
        {
            SceneManager.LoadScene("pk");
            pk.enabled = false;
        }
        else if (collision.gameObject.name == "Rabbit" && gameObject.name == "quitCarrot")
        {
            Application.Quit();
            quit.enabled = false;
        }

    }
}
