using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIrabbitMove : MonoBehaviour
{
    Animator anim;
    [Header("Key Setting")]
    public KeyCode Key_Right = KeyCode.D;
    public KeyCode Key_Left = KeyCode.A;
    public KeyCode Key_Fight = KeyCode.S;

    private bool sMove = false;
    private int willTo = 0;
    private Vector3 endpos;
    private float process = 0;

    float timer_f = 0.02f;
    float nextKeyTime = 0.0f;

    // Use this for initialization
    void Start()
    {
        this.transform.position = new Vector3(-5f, 2.0f, 0.0f);
        anim = transform.Find("Main").GetComponent<Animator>();

        anim.SetTrigger("jumpL");
        anim.SetBool("Be_fallRound", true);
        endpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Key_Right))
        {
            if (willTo <= 1)
            {

                willTo++;
                anim.SetTrigger("jumpR");
                anim.SetBool("Be_fallRound", true);
                process = 0;
                sMove = true;
                endpos = new Vector3(-5 + willTo * 5, this.transform.position.y, 0);
            }
        }
           
        if (Input.GetKeyDown(Key_Left))
        {
            if (willTo >= 1)
            {
                willTo--;
                anim.SetTrigger("jumpL");
                anim.SetBool("Be_fallRound", true);
                process = 0;
                sMove = true;
                endpos = new Vector3(-5 + willTo * 5, this.transform.position.y, 0);
            }
        }

        if (Input.GetKeyDown(Key_Fight))
        {
            if (!sMove)
            {
                anim.SetTrigger("down");
                endpos = new Vector3(endpos.x, this.transform.position.y - 2.25f, 0);
                process = 0;
                sMove = true;
            }
        }

        if (sMove)
        {
            process += Time.deltaTime * 2;
            if (process < 1)
                this.transform.position = Vector3.Lerp(this.transform.position, endpos, process);
            else
            {
                sMove = false;
            }
        }
    }
}
