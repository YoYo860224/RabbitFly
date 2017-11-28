using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chooseStage : MonoBehaviour {

    public GameObject stage1Carrot;
    public GameObject stage2Carrot;
    public GameObject stage3Carrot;
    public GameObject changeChoosePanel;

    void Start(){
        changeChoosePanel.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Rabbit" && gameObject.name == "stage1")
        {
            this.GetComponent<Animator>().SetBool("hitCarrot", true);
            this.Invoke("changeChoose", 0.7f);
            this.Invoke("loadchoose", 2.0f);
        }
        else if (collision.gameObject.name == "Rabbit" && gameObject.name == "stage2")
        {
            this.GetComponent<Animator>().SetBool("hitCarrot", true);
            this.Invoke("changeChoose", 0.7f);
            this.Invoke("loadchoose", 2.0f);
        }
        else if (collision.gameObject.name == "Rabbit" && gameObject.name == "stage3")
        {
            this.GetComponent<Animator>().SetBool("hitCarrot", true);
            this.Invoke("changeChoose", 0.7f);
            this.Invoke("loadBoSS", 2.0f);

        }
    }
    private void changeChoose(){
        changeChoosePanel.SetActive(true);
    }
    private void loadchoose()
    {
        SceneManager.LoadSceneAsync("TestScene");
    }

    private void loadBoSS()
    {
        SceneManager.LoadSceneAsync("bossScene"); 
    }
}
