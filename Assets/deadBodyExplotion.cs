using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadBodyExplotion : MonoBehaviour {

    // Use this for initialization
    void Start() {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject myChild = transform.GetChild(i).gameObject;
            myChild.transform.localPosition = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f));
            myChild.GetComponent<Rigidbody2D>().AddForceAtPosition(10000 * (myChild.transform.position - transform.position), transform.position);
        }
    }
	
	// Update is called once per frame
	void Update () {


    }
    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject myChild = transform.GetChild(i).gameObject;
            myChild.transform.localPosition = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f));
            myChild.GetComponent<Rigidbody2D>().AddForceAtPosition(10000 * (myChild.transform.position - transform.position), transform.position);
        }
    }


}
