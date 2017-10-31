using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {
    Animator anim;
    [SerializeField] LayerMask whatIsGround;
    Transform groundCheck;
    float groundedRadius = 1.0f;
    bool grounded = true;

    // Use this for initialization
    void Start () {
        //groundCheck = transform.Find("GroundCheck");
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.OverlapCircle(transform.position, groundedRadius, whatIsGround);
        anim.SetBool("isGround", grounded);
        Debug.Log(grounded);
        if (Input.GetKeyDown(KeyCode.D)){
            //anim.SetBool("isGround", false);
            anim.SetTrigger("jumpR");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(1000, 2000));
            grounded = false;

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //anim.SetBool("isGround", false);
            anim.SetTrigger("jumpL");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000, 2000));
            grounded = false;
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            //anim.SetBool("isGround", true);
            anim.SetTrigger("down");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -10000));
        }

    }
}
