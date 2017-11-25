using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PKlife : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Restart();

    }

    void Restart()
    {
        Application.LoadLevelAsync("PKMode");
    }

    public void GetHrut()
    {
        // 死亡動畫
        GetComponent<Control>().enabled = false;
        Destroy(GetComponent<Collider2D>());
        Destroy(GetComponent<Rigidbody2D>());
        transform.Find("Main").gameObject.SetActive(false);
        transform.Find("Foot").gameObject.SetActive(false);
        transform.Find("DeadBody").gameObject.SetActive(true);

        // 跳死亡選單
        {

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Trap"))
        {
            if (GetComponent<Control>().grounded)
                GetHrut();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Rabbit"))
        {
            if (transform.Find("Main").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("down"))
            {
                if (transform.position.y > collision.transform.position.y)
                    collision.gameObject.GetComponent<PKlife>().GetHrut();
            }
            if (transform.Find("Main").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("roundR"))
            {
                //if (transform.position.y < collision.transform.position.y)
                    transform.gameObject.GetComponent<Control>().jumpR();
            }
            if (transform.Find("Main").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("roundL"))
            {
                //if (transform.position.y < collision.transform.position.y)
                    transform.gameObject.GetComponent<Control>().jumpL();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Rabbit"))
        {
            if (transform.Find("Main").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("down"))
            {
                if (transform.position.y > collision.transform.position.y)
                {
                    collision.gameObject.GetComponent<PKlife>().GetHrut();

                }
            }
        }

    }
}
