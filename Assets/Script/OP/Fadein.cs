using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadein : MonoBehaviour {
    bool a = true;
    public float repeattime = 0.075f;
    // Use this for initialization
    void Start () {
        GetComponent<Image>().color = new Color(255, 255, 225, 0);
        this.InvokeRepeating("Fade_in", 0.5f, repeattime);
    }

    // Update is called once per frame
    void Update()
    { 
    }
    private void Fade_in()
    {
        if (GetComponent<Image>().color.a < 1.2f) {
            GetComponent<Image>().color = new Color(255, 255, 225, GetComponent<Image>().color.a + 0.03f);
        }
        Debug.Log(GetComponent<Image>().color.a);
    }
}
