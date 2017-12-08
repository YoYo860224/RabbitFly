using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy1ToDie : MonoBehaviour {
    Animator anim;
    bool isdead;
    float initx;

    [Header("Set Move parameter")]

    public float moveR = 1.0f;
    public float moveL = 1.0f;
    public float speed = 0.5f;

    [Header("Set Colider for flip")]
    public Collider2D Collider_now;
    public Collider2D Collider_flipX;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        initx = transform.position.x;

        //speed += Random.Range(-0.2f, 0.2f);
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if (!isdead)
        {
            // 換方向
            if (transform.position.x < initx - moveL)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                Collider_now.enabled = false;
                Collider_flipX.enabled = true;
            }
            else if (transform.position.x > initx + moveR)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                Collider_now.enabled = true;
                Collider_flipX.enabled = false;
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
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Rabbit"))
        {

            if (!collision.transform.Find("Main").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("down"))
            {
                if (!collision.gameObject.GetComponent<RabbitInfo>().GetHrut())
                    collision.gameObject.GetComponent<Control>().TopJump();
            }
            else
            {
                if (!isdead)
                {
                    collision.gameObject.GetComponent<RabbitInfo>().AddCombo();
                    collision.gameObject.GetComponent<Control>().TopJump();
                    EnemyDead();
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Rabbit"))
        {

            if (!collision.transform.Find("Main").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("down"))
            {
                if (!collision.gameObject.GetComponent<RabbitInfo>().GetHrut())
                    collision.gameObject.GetComponent<Control>().TopJump();
            }
            else
            {
                if (!isdead)
                {
                    collision.gameObject.GetComponent<RabbitInfo>().AddCombo();
                    collision.gameObject.GetComponent<Control>().TopJump();
                    EnemyDead();
                }
            }
        }
    }

    private void EnemyDead()
    {
        anim.SetTrigger("dead");
        isdead = true;
        Destroy(Collider_now);
        Destroy(Collider_flipX);
        Destroy(GetComponent<Rigidbody2D>());
        this.InvokeRepeating("DoFadeOut", 0.1f, 0.05f);
    }
    private void DoFadeOut()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, GetComponent<SpriteRenderer>().color.a - 0.03f);
        if (GetComponent<SpriteRenderer>().color.a < 0)
            Destroy(gameObject);
    }
 }
