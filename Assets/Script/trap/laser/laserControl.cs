using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserControl : MonoBehaviour {

    public Animator anim;

    public float laserOffTime;
    public float laserOnTime;

    void Start ()
    {
        float repeatDoTime = laserOffTime + laserOnTime;
        InvokeRepeating("Timer_laser",1, repeatDoTime);
	}

    void Update()
    {

    }

    void Timer_laser()
    {
        anim.SetBool("switch", true);
        GetComponent<Collider2D>().enabled = true;
        Invoke("Off_laser", laserOnTime);
    }

    void Off_laser()
    {
        anim.SetBool("switch", false);
        GetComponent<Collider2D>().enabled = false;
    }
}
