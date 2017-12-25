using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightStart : MonoBehaviour {

   public  GameObject fightpic;
    public GameObject afterOp;
    public int once = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Rabbit"))
        {
            if (once < 100)
            {
                collision.gameObject.GetComponent<Control>().SetControl(true);
                GetComponent<AutoUp>().enabled = true;
                foreach (var i in Camera.main.gameObject.GetComponent<AutoCreate>().allB)
                {
                    i.active = true;
                }
                fightpic.SetActive(true);
                Invoke("stattttt", 3.0f);
            }
            once ++;
        }
    }

    void stattttt()
    {
        afterOp.active = true;
    }
}
