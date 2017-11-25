using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, GetComponent<SpriteRenderer>().color.a - 0.03f);
        if (GetComponent<SpriteRenderer>().color.a < 0)
            Destroy(gameObject);
	}
}
