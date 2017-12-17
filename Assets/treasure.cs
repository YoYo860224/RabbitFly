using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasure : MonoBehaviour {

    public GameObject winPlot;

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
            GetComponent<Animator>().enabled = true;
            Invoke("papapa", 1.5f);
        }
    }

    void papapa()
    {
        transform.Find("good").gameObject.active = true;
        winPlot.active = true;
        UIcontroller.UIcontroll.delayDo("openWin", 1.0f);
    }
}
