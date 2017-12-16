using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlotScript : MonoBehaviour {
    public GameObject[] image;
    public int now;
    public string nextScene;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (image[now].GetComponent<Image>().color.a < 1)
        {
            image[now].GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
            if (Input.anyKey)
            {
                image[now].GetComponent<Image>().color += new Color(0, 0, 0, 0.05f);
            }
        }
        else
        {
            if (now < image.Length - 1)
                now++;
        }
    }

    public void OpenNext()
    {
        SceneManager.LoadSceneAsync(nextScene);
    }
}
