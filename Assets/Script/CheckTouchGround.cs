using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTouchGround: MonoBehaviour {
    public Animator anim;
    [SerializeField] LayerMask whatIsGround;
    public int combo;
    public int bounce_force;
    public GameObject Rabbit;
	// Use this for initialization
	void Start () {
        //anim = transform.Find("Main").GetComponent<Animator>();  //  Get From Public
    }

    // Update is called once per frame
    void Update () {
        Debug.Log("combo: " + combo);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            anim.SetBool("isGround", true);
            combo = 0;
        }
            
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Rabbit.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bounce_force));
            combo++;
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            anim.SetBool("isGround", false);
        }
            
    }
}
