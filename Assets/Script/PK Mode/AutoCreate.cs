using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCreate : MonoBehaviour {
    Vector3[][] theVec = {
        new Vector3[] 
        {
            new Vector3(-0.43f, 0.00f, 0),
            new Vector3(-2.52f, 1.65f, 0),
            new Vector3( 1.57f, 2.52f, 0),
            new Vector3(-0.82f, 4.26f, 0),
            new Vector3( 2.98f, 5.24f, 0)
        },
        new Vector3[]
        {
            new Vector3(-3.69f, 0.00f, 0),
            new Vector3(-2.52f, 2.50f, 0),
            new Vector3( 1.13f, 4.50f, 0),
            new Vector3( 0.00f, 7.00f, 0),
            new Vector3( 1.13f, 4.50f, 0),
            new Vector3( 2.52f, 2.50f, 0),
            new Vector3( 3.69f, 0.00f, 0)
        },
        new Vector3[]
        {
            new Vector3(-1.00f, 2.50f, 0),
            new Vector3(-0.33f, 2.50f, 0),
            new Vector3( 0.33f, 2.50f, 0),
            new Vector3( 1.00f, 2.50f, 0)
        }
    };

    public Transform PkEnd;
    public GameObject pre_Broken;
  
    public Vector3 start;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 80; i++)
        {
            int use = Random.Range(0, 3);
            for (int j = 0; j < theVec[use].Length; j++)
                if (Random.Range(0.0f, 1.0f) > 0.2f)
                {
                    GameObject TheB = Instantiate<GameObject>(pre_Broken, new Vector3(0, start.y + (float)i * 7.7f, 0) + theVec[use][j], pre_Broken.transform.rotation);
                    TheB.GetComponent<BrokenPlatform>().forPkEnd = PkEnd;
                }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
