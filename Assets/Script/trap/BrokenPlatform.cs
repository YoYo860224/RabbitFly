using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatform : MonoBehaviour {

    public Transform forPkEnd; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (forPkEnd)
        {
            if (forPkEnd.position.y > transform.position.y)
            {
                broke(); 
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rabbit")
        {
            if (collision.transform.Find("Main").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("down"))
            {
                GetComponent<Collider2D>().enabled = false;
                broke();
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

    public void broke()
    {
        transform.Find("mid").gameObject.SetActive(false);
        transform.Find("broken").gameObject.SetActive(true);
        Destroy(gameObject, 10.0f);
    }
}
