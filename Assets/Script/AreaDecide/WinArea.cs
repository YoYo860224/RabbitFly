using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinArea : MonoBehaviour {

    public GameObject smotothCam;
    public int winToStageWhat;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Rabbit"))
        {
            UIcontroller.UIcontroll.delayDo("openWin",1.0f);
            smotothCam.GetComponent<CameraFollow>().TopDownOffset = 0;
            SetRecord(winToStageWhat);
        }
    }

    public void SetRecord(int v)
    {
        PlayerPrefs.SetInt("record", v);
        Camera.main.GetComponent<TheSetting>().allSetUpdate();
    }
}