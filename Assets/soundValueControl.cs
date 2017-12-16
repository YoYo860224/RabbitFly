using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundValueControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("sound_value");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
