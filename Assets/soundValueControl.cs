using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundValueControl : MonoBehaviour {

    public float rate = 1.0f;

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("sound_value") * rate;
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("sound_value") * rate;
    }
}
