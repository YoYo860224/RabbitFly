using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeKey : MonoBehaviour {

    public string changeWhat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (changeWhat != null)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey))
                {
                    PlayerPrefs.SetInt(changeWhat, (int)vKey);
                    changeWhat = null;
                    this.enabled = false;
                }
            }
        }
	}
}
