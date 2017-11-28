using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinArea : MonoBehaviour {

    public GameObject smotothCam;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rabbit")
        {
            Camera.main.GetComponent<UIcontroller>().openFinish();
            smotothCam.GetComponent<CameraFollow>().TopDownOffset = 0;

        }
    }
}