using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcarrotMove : MonoBehaviour
{
    public Animator anim;

    bool isdead;
    float initx;
    public float moveR = 2.0f;
    public float moveL = 2.0f;
    public float speed = 1.5f;

    // keep form stuck_move
    int allRecordTimes = 60;
    int nowRecordTimes = 0;
    float ori_pos;


    // Use this for initialization
    void Start()
    {
        anim = this.GetComponent<Animator>();
        initx = transform.position.x;
        ori_pos = transform.position.x;

        speed += Random.RandomRange(1.0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
      
        
        
        
        
        /* if (!isdead)
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

    */
    }
}
