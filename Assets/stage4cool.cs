using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage4cool : MonoBehaviour {
    public GameObject[] appear;
    public GameObject[] disappear;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Rabbit")
        {
            foreach(GameObject i in appear)
            {
                i.active = true;
            }
            foreach (GameObject i in disappear)
            {
                i.active = false;
            }
        }
    }
}
