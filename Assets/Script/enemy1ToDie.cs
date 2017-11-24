using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1ToDie : MonoBehaviour {
    public Animator anim;

    bool isdead;
    float initx;
    public float moveR = 1.0f;
    public float moveL = 1.0f;
    public float speed = 0.5f;

    // keep form stuck_move
    int allRecordTimes = 60;
    int nowRecordTimes = 0;
    float ori_pos;


    // Use this for initialization
    void Start () {
        anim = this.GetComponent<Animator>();
        initx = transform.position.x;
        ori_pos = transform.position.x;

        speed += Random.Range(-0.2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isdead)
        {
            // 換方向
            if (transform.position.x < initx - moveL)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (transform.position.x > initx + moveR)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

            // 移動
            if (GetComponent<SpriteRenderer>().flipX)
            {
                transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
            }
            else
            {
                transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);
            }


            // keep form stuck_move
            if (nowRecordTimes < allRecordTimes)
            {
                nowRecordTimes++;
            }
            else
            {
                nowRecordTimes = 0;
                if (Mathf.Abs(transform.position.x - ori_pos) < 0.1f)
                    GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                ori_pos = transform.position.x;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Rabbit"))
        {
            if (collision.gameObject.name == "Rabbit")
            {
                if (!collision.transform.Find("Main").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("down"))
                {
                    collision.gameObject.GetComponent<RabbitInfo>().GetHrut();
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Rabbit"))
        {
            if (collision.gameObject.name == "Foot")
            {    
                    anim.SetTrigger("dead");
                    isdead = true;
                    Destroy(GetComponent<Collider2D>());
                    Destroy(GetComponent<Rigidbody2D>());
                    this.InvokeRepeating("DoFadeOut", 0.1f, 0.05f);
            }
        }
    }

    private void DoFadeOut()
    {
        //Debug.Log("dead");
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, GetComponent<SpriteRenderer>().color.a - 0.03f);
        if (GetComponent<SpriteRenderer>().color.a < 0)
            Destroy(gameObject);
    }


}
