using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {
    //  get animator
    public Animator anim;

    // force Control
    public int x_force;
    public int y_force;
    public int down_force;

    //  checkGround
    /* Set Ground detect in GameObject foot*/
    bool grounded = false;

    //  Find Heightest
    Vector3 prePos;
    Vector3 nowPos;

    // Use this for initialization
    void Start () {
        //anim = transform.Find("Main").GetComponent<Animator>();  //  Get From Public
        prePos = transform.position;
        nowPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        grounded = anim.GetBool("isGround");

        #region Key_Control
        if (Input.GetKeyDown(KeyCode.D)){
            anim.SetTrigger("jumpR");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(x_force, y_force));
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("jumpL");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-x_force, y_force));
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!grounded)
            {
                anim.SetTrigger("down");
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -down_force));
            }
        }
        #endregion


        prePos = nowPos;
        nowPos = transform.position;

        if (prePos.y > nowPos.y && !grounded)
            anim.SetBool("Be_fallRound", true);
        else
            anim.SetBool("Be_fallRound", false);
    }
}
