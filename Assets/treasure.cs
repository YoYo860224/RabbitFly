using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasure : MonoBehaviour {

    public GameObject winPlot;

    public GameObject backMusic;
    public AudioClip music;


    private int ggg = 0;

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
            collision.GetComponent<Control>().canControl = false;
            Invoke("papapa", 1.5f);
        }
    }

    void papapa()
    {
        transform.Find("good").gameObject.active = true;
        winPlot.active = true;
        UIcontroller.UIcontroll.delayDo("openWin", 1.0f);

        if (ggg == 0)
        {
            ggg = 1;
            backMusic.GetComponent<AudioSource>().clip = music;
            backMusic.GetComponent<AudioSource>().loop = false;
            backMusic.GetComponent<AudioSource>().Play();

        }
    }
}
