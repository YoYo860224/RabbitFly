using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, GetComponent<SpriteRenderer>().color.a - 0.03f);
        if (GetComponent<SpriteRenderer>().color.a < 0)
            Destroy(gameObject);
	}
}
