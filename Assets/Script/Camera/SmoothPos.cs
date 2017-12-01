using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothPos : MonoBehaviour {
    public Transform followTarget;
    public float Radius;
    public float Smooth;

    private Vector3 smoothPosition = Vector3.zero;

    // Use this for initialization
    void Start () {
        if (!followTarget)
            this.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(transform.position.y - followTarget.position.y) > Radius)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position, Smooth * Time.deltaTime);
        }
	}
}
