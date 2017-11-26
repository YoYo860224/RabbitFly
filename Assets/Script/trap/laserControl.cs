using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserControl : MonoBehaviour {
    public Animator anim;
    public float repeat_time;
    public float laser_ontime;
    // Use this for initialization
    void Start () {
        InvokeRepeating("Timer_laser",1, repeat_time);
	}
	void Timer_laser()
    {
        anim.SetBool("switch", true);
        GetComponent<Collider2D>().enabled = true;
        Invoke("Off_laser", laser_ontime);
    }
    void Off_laser()
    {
        anim.SetBool("switch", false);
        GetComponent<Collider2D>().enabled = false;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
