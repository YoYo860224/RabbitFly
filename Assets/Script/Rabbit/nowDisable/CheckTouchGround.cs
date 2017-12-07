using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTouchGround: MonoBehaviour {

    public GameObject Rabbit;
    public Animator anim;

	// Use this for initialization
	void Start () {
        Rabbit = transform.parent.gameObject;                    //  Get From Public
        anim = transform.Find("Main").GetComponent<Animator>();  //  Get From Public
    }

    // Update is called once per frame
    void Update () {
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("nt_Ground"))
        {
            if (collision.GetComponent<Collider2D>().isTrigger == false)
            {
                transform.parent.GetComponent<Control>().SetGround(true);
                if(transform.parent.GetComponent<RabbitInfo>())
                    transform.parent.GetComponent<RabbitInfo>().ResetCombo();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("nt_Ground"))
        {
            if (collision.GetComponent<Collider2D>().isTrigger == false)
            {
                transform.parent.GetComponent<Control>().SetGround(true);
                if (transform.parent.GetComponent<RabbitInfo>())
                    transform.parent.GetComponent<RabbitInfo>().ResetCombo();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("nt_Ground"))
        {
            transform.parent.GetComponent<Control>().SetGround(false);
        }
            
    }
}