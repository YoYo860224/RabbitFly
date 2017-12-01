using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartClick : MonoBehaviour {
    public GameObject crossPanel;
    void Start() {
        crossPanel.SetActive(false);
    }
    public void click1()
    {
        crossPanel.SetActive(true);
        crossPanel.transform.localScale = new Vector3(1, 1, 1);////(1)
        StartCoroutine(DisplayLoadingScreen("TestScene"));////(2)
        Debug.Log(1);
    }
    
    IEnumerator DisplayLoadingScreen(string sceneName)
    {////(1)
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);////(2)
        //while (!async.isDone)
        //{////(3)
        //    loadText.text = (async.progress * 100).ToString() + "%";////(4)
        //    loadImage.transform.localScale = new Vector2(async.progress, loadImage.transform.localScale.y);
        yield return null;
        //}
    }
}
