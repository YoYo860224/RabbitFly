using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformInfo : MonoBehaviour {

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
            if (collision.transform.Find("Main").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("down"))
            {
                GetComponent<Collider2D>().enabled = false;
                transform.Find("StressToDie").gameObject.SetActive(false);
                transform.Find("mid").gameObject.SetActive(false);
                transform.Find("broken").gameObject.SetActive(true);
            }
            else
            {
                GetComponent<Collider2D>().isTrigger = false;
            }
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
}
