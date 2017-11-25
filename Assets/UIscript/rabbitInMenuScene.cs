using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class rabbitInMenuScene : MonoBehaviour {

    public GameObject changeChoosePanel;
    public GameObject arrowPanel;
    public GameObject storyCarrot;
    public GameObject pKCarrot;
    public GameObject quitCarrot;
    // Use this for initialization
    void Start()
    {
        changeChoosePanel.SetActive(false);
        arrowPanel.SetActive(true);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Rabbit" && gameObject.name == "storyCarrot")
        {
            this.GetComponent<Animator>().SetBool("hitCarrot", true);
            storyCarrot.GetComponent<BoxCollider2D>().enabled = false;
            pKCarrot.GetComponent<BoxCollider2D>().enabled = false;
            quitCarrot.GetComponent<BoxCollider2D>().enabled = false;
            this.Invoke("changeChoose", 0.7f);
            this.Invoke("loadchoose", 2.0f);
        }

        else if (collision.gameObject.name == "Rabbit" && gameObject.name == "pkCarrot")
        {
            this.GetComponent<Animator>().SetBool("hitCarrot", true);
            storyCarrot.GetComponent<BoxCollider2D>().enabled = false;
            pKCarrot.GetComponent<BoxCollider2D>().enabled = false;
            quitCarrot.GetComponent<BoxCollider2D>().enabled = false;
            this.Invoke("changeChoose", 0.7f);
            this.Invoke("loadpk", 2.0f);
        }
        else if (collision.gameObject.name == "Rabbit" && gameObject.name == "quitCarrot")
        {
            this.GetComponent<Animator>().SetBool("hitCarrot", true);
            Application.Quit();
            storyCarrot.GetComponent<BoxCollider2D>().enabled = false;
            pKCarrot.GetComponent<BoxCollider2D>().enabled = false;
            quitCarrot.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void loadchoose() {
        SceneManager.LoadSceneAsync("chooseScene");
    }
    private void changeChoose() {
        changeChoosePanel.SetActive(true);
    }
    private void loadpk() {
        SceneManager.LoadSceneAsync("PKMode");
    }
}
