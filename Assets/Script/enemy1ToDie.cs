using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1ToDie : MonoBehaviour {
    public Animator anim;
	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Rabbit"))
        {
            anim.SetTrigger("dead");
            this.InvokeRepeating("fadeOut",0.1f,0.05f);
        }
            
    }

    private void fadeOut()
    {
        Debug.Log("dead");
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, GetComponent<SpriteRenderer>().color.a - 0.03f);
        if (GetComponent<SpriteRenderer>().color.a < 0)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
