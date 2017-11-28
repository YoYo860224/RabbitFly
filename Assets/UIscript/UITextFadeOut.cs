﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextFadeOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().color = new Color(255, 255, 255, GetComponent<Text>().color.a - 0.03f);
        if (GetComponent<Text>().color.a < 0)
            gameObject.SetActive(false);
    }
}
