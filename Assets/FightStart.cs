using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightStart : MonoBehaviour {

   public  GameObject fightpic;

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
            collision.gameObject.GetComponent<Control>().SetControl(true);
            GetComponent<AutoUp>().enabled = true;
            Camera.main.gameObject.GetComponent<AutoCreate>().enabled = true;
            fightpic.SetActive(true);
        }
    }
}
