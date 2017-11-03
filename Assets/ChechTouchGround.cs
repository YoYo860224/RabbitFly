using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChechTouchGround : MonoBehaviour {
    public Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.layer.ToString() == "8")
        {
            Debug.Log(true);
            anim.SetBool("isGround", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer.ToString());
        if (collision.gameObject.layer.ToString() == "8")
        {
            Debug.Log(false);
            anim.SetBool("isGround", false);
        }
    }
}
