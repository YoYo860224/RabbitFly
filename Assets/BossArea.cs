using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArea : MonoBehaviour {

    public bool bossStage;
    public GameObject smotothCam;

	// Use this for initialization
	void Start () {
        bossStage = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rabbit")
        {
            bossStage = true;
            smotothCam.GetComponent<CameraFollow>().TopDownOffset = 0;
        }
    }
}
