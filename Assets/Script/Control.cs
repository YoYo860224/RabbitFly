using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {
    //  get animator
    public Animator anim;
    public GameObject push_prefab;

    // force Control
    public int x_force;
    public int y_force;
    public int down_force;

    public int normal_Speed_Limit;
    public int superDown_Speed_Limit;

    // delayT for keep from cheat
    float timer_f = 0.02f;
    float nextKeyTime = 0.0f;

    //  checkGround
    /* Set Ground detect in GameObject foot*/
    public bool grounded = false;

    //  Find Heightest
    Vector3 prePos;
    Vector3 nowPos;

    // Key Setting
    public KeyCode Key_Right = KeyCode.D;
    public KeyCode Key_Left = KeyCode.A;
    public KeyCode Key_Fight = KeyCode.S;


    // Use this for initialization
    void Start () {
        //anim = transform.Find("Main").GetComponent<Animator>();  //  Get From Public
        prePos = transform.position;
        nowPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = anim.GetBool("isGround");

        #region Key_Control
        if (Time.time > nextKeyTime)
        {
            if (Input.GetKeyDown(Key_Right))
            {
                anim.ResetTrigger("jumpL");
                anim.ResetTrigger("down");
                anim.SetTrigger("jumpR");
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(x_force, y_force));
                Instantiate(push_prefab, transform.Find("Foot").position, transform.Find("Foot").rotation);
                nextKeyTime = Time.time + timer_f;
            }

            else if (Input.GetKeyDown(Key_Left))
            {
                anim.ResetTrigger("jumpR");
                anim.ResetTrigger("down");
                anim.SetTrigger("jumpL");
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-x_force, y_force));
                Instantiate(push_prefab, transform.Find("Foot").position, transform.Find("Foot").rotation);
                nextKeyTime = Time.time + timer_f;
            }

            else if (Input.GetKeyDown(Key_Fight))
            {
                if (!grounded)
                {
                    if (!anim.GetCurrentAnimatorStateInfo(0).IsName("down"))
                    {
                        anim.ResetTrigger("jumpR");
                        anim.ResetTrigger("jumpL");
                        anim.SetTrigger("down");
                    }
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -down_force));
                }
                nextKeyTime = Time.time + timer_f;
            }
        }
        #endregion


        prePos = nowPos;
        nowPos = transform.position;

        if (prePos.y > nowPos.y && !grounded)
            anim.SetBool("Be_fallRound", true);
        else
            anim.SetBool("Be_fallRound", false);

        //Debug.Log(GetComponent<Rigidbody2D>().velocity);


        if (anim.GetCurrentAnimatorStateInfo(0).IsName("down"))
        {
            if (GetComponent<Rigidbody2D>().velocity.y < -superDown_Speed_Limit)
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -superDown_Speed_Limit);
        }
        else
        {
            if (GetComponent<Rigidbody2D>().velocity.y < -normal_Speed_Limit)
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -normal_Speed_Limit);
        }
    }
}
