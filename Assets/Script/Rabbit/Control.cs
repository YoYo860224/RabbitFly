using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    Animator anim;

    [Header("Key Setting")]
    public bool canControl = true;
    public KeyCode Key_Right = KeyCode.D;
    public KeyCode Key_Left = KeyCode.A;
    public KeyCode Key_Fight = KeyCode.S;

    [Header("pushModel")]
    public GameObject push_prefab;

    [Header("Speed and Force Control")]
    public int x_force;
    public int y_force;
    public int down_force;
    public float jump_force;

    public int normal_Speed_Limit;
    public int superDown_Speed_Limit;

    [Header("Debug To See")]
    //  checkGround
    public bool grounded = false;

    //  Find Heightest
    Vector3 prePos;
    Vector3 nowPos;

    // delayTime for keep from cheat
    float timer_f = 0.02f;
    float nextKeyTime = 0.0f;

    // Use this for initialization
    void Start()
    {
        anim = transform.Find("Main").GetComponent<Animator>();

        prePos = transform.position;
        nowPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isGround", grounded);

        if (canControl)
        {
            #region Key_Control
            if (Time.time > nextKeyTime)
            {
                if (Input.GetKeyDown(Key_Right))
                {
                    anim.ResetTrigger("jumpL");
                    anim.ResetTrigger("down");
                    anim.SetTrigger("jumpR");
                    jumpR();
                    Instantiate(push_prefab, transform.Find("Foot").position, transform.Find("Foot").rotation);
                    nextKeyTime = Time.time + timer_f;
                }

                else if (Input.GetKeyDown(Key_Left))
                {
                    anim.ResetTrigger("jumpR");
                    anim.ResetTrigger("down");
                    anim.SetTrigger("jumpL");
                    jumpL();
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
        }

        // 檢查是否下降
        prePos = nowPos;
        nowPos = transform.position;

        if (prePos.y > nowPos.y)
            anim.SetBool("Be_fallRound", true);
        else
            anim.SetBool("Be_fallRound", false);


        // 固定下降速度
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

    public void SetGround(bool value)
    {
        grounded = value;
    }

    public void SetControl(bool val)
    {
        canControl = val;
    }

    public void TopJump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump_force));
    }
    public void TopJump(float force)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force));
    }

    public void jumpR()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(x_force, y_force));
    }
    public void jumpL()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-x_force, y_force));
    }

    
}
