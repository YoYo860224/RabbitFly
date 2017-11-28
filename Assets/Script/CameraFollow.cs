using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject theCamera;
    public float TopDownOffset;
    float nowTopDownOffset;
    // Use this for initialization
    void Start () {
        nowTopDownOffset = TopDownOffset;

    }
	
	// Update is called once per frame
	void Update () {
        nowTopDownOffset = Mathf.Lerp(nowTopDownOffset, TopDownOffset, 0.05f);

        if (transform.position.y < nowTopDownOffset)
            theCamera.transform.position = new Vector3(theCamera.transform.position.x, transform.position.y- nowTopDownOffset, theCamera.transform.position.z);
	}
}