using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {
    //  get animator
    Animator anim;

    //  checkGround
    [SerializeField] LayerMask whatIsGround;
    float groundedRadius = 1.0f;
    bool grounded = true;

    //  Fint Heightest
    Vector3 prePos;
    Vector3 nowPos;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        prePos = transform.position;
        nowPos = transform.position;
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
            //grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //anim.SetBool("isGround", false);
            anim.SetTrigger("jumpL");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000, 2000));
            //grounded = false;
        }

        //  goDown
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!grounded)
            {
                anim.SetTrigger("down");
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -10000));
            }
        }

        prePos = nowPos;
        nowPos = transform.position;

        if (prePos.y > nowPos.y && !grounded)
            anim.SetBool("Be_fallRound", true);
        else
            anim.SetBool("Be_fallRound", false);
    }
}
