using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChengeScence : MonoBehaviour {
    public int x = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void scenceChange()
    {
        SceneManager.LoadScene("Sce");
    }
}
