using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
    Animator anim;

    [Header("Debug To See")]
    //  checkGround
    public bool grounded = false;

    void Start()
    { 
        anim = transform.Find("Main").GetComponent<Animator>();  //  Get From Public
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("nt_Ground")
            || collision.gameObject.layer == LayerMask.NameToLayer("nt_ColliderTrap"))
        {
            if (collision.gameObject.GetComponent<Collider2D>().isTrigger == false)
            {
                GetComponent<Control>().SetGround(true);
                if (GetComponent<RabbitInfo>())
                    GetComponent<RabbitInfo>().ResetCombo();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("nt_Ground")
            || collision.gameObject.layer == LayerMask.NameToLayer("nt_ColliderTrap"))
        {
            if (collision.gameObject.GetComponent<Collider2D>().isTrigger == false)
            {
                GetComponent<Control>().SetGround(true);
                if (GetComponent<RabbitInfo>())
                    GetComponent<RabbitInfo>().ResetCombo();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("nt_Ground")
            || collision.gameObject.layer == LayerMask.NameToLayer("nt_ColliderTrap"))
        {
            GetComponent<Control>().SetGround(false);
        }
    }
}
