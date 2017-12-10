using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheLasor : MonoBehaviour {

    public Animator anim;
    public float readyTime;
    public float stayTime;

    private bool shine = true;
    private bool shineLow = true;

    public bool AutoDo = false;

    // Use this for initialization
    void Start () {
        anim.SetBool("switch", true);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);

        // for Debug
        if (AutoDo)
            Set(readyTime, stayTime);
    }
	
	// Update is called once per frame
	void Update () {
        if (shine)
        {
            if (GetComponent<SpriteRenderer>().color.a > 0.5f)
                shineLow = true;
            else if (GetComponent<SpriteRenderer>().color.a < 0)
                shineLow = false;


            if(shineLow)
                GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.1f);
            else
                GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.1f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
    }
    public void Set(float r, float stay)
    {
        readyTime = r;
        stayTime = stay;
        Invoke("To_laser", readyTime);
        Invoke("Off_laser", readyTime + stayTime);
    }


    void To_laser()
    {
        shine = false;
        GetComponent<Collider2D>().enabled = true;
    }

    void Off_laser()
    {
        DestroyObject(transform.parent.gameObject);
    }
}
