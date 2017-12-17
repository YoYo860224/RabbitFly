using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage4Camera : MonoBehaviour {
    public Transform followTarget;
    public float Radius;
    public float Smooth;
    float nowTopDownOffset;
    // Use this for initialization
    void Start()
    {
        if (!followTarget)
            this.enabled = false;

        nowTopDownOffset = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Mathf.Abs(transform.position.y - followTarget.position.y) > Radius)
         {
             transform.position = Vector3.Lerp(transform.position, followTarget.position, Smooth * Time.deltaTime);
         }*/

        if (Mathf.Abs(transform.position.x - followTarget.position.x) > Radius)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position, Smooth * Time.deltaTime);
        }

        /* nowTopDownOffset = Mathf.Lerp(nowTopDownOffset, 0, 0.05f);

         if (transform.position.y < nowTopDownOffset)
             Camera.main.transform.position = new Vector3(transform.position.x - nowTopDownOffset, Camera.main.transform.position.y, Camera.main.transform.position.z);
     }*/


        if (transform.position.x >= -1)
            Camera.main.transform.position = new Vector3(transform.position.x + 2.0f, 0, -10);
        else
            Camera.main.transform.position = new Vector3(1.0f, 0, -10);
    }
}
