using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotDoWhat : MonoBehaviour {

    public bool IAmStoryCarrot;
    public bool IAmPkCarrot;
    public bool IAmQuitCarrot;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<SpriteRenderer>().sortingOrder = 1;
        if (IAmStoryCarrot)
        {
            GameObject.Find("MenuUI").GetComponent<UiInMenu>().DoStroyCarrot();
        }

        else if (IAmPkCarrot)
        {
            GameObject.Find("MenuUI").GetComponent<UiInMenu>().DoPkCarrot();
        }
        else if (IAmQuitCarrot)
        {
            GameObject.Find("MenuUI").GetComponent<UiInMenu>().DoQuitCarrot();
        }
    }
}
