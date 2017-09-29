using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSet : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex",new Vector2(0, transform.parent.position.y/50));
    }
}
