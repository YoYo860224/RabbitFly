using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Awake : MonoBehaviour {
   public GameObject image1, image2, image3, image4, image5;
	// Use this for initialization
	void Start () {
        awake();
        //this.Invoke("awake", 3);
    }
	
	// Update is called once per frame
	void Update () {
        if (image1.GetComponent<Image>().color.a >= 1 && image2.GetComponent<Fadein>().enabled == false) {
            image2.GetComponent<Fadein>().enabled = true;
        }
        else if (image2.GetComponent<Image>().color.a >= 1 && image3.GetComponent<Fadein>().enabled == false)
        {
            image3.GetComponent<Fadein>().enabled = true;
        }
        else if (image3.GetComponent<Image>().color.a >= 1 && image4.GetComponent<Fadein>().enabled == false)
        {
            image4.GetComponent<Fadein>().enabled = true;
        }
        else if (image4.GetComponent<Image>().color.a >= 1 && image5.GetComponent<Fadein>().enabled == false)
        {
            image5.GetComponent<Fadein>().enabled = true;
        }
    }
    void awake() {
        image1.GetComponent<Fadein>().enabled = true;
    }
}
