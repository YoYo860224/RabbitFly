using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCreate : MonoBehaviour {
    bool[,] theBroken = new bool [8,8];
//    float[] thePos = { -3.5f, -2.5f, -1.5f, -0.5f, 0.5f, 1.5f, 2.5f, 3.5f };
    float[] thePos = { -2.5f,  -1.0f, 1.0f, 2.5f };
    public GameObject pre_Broken;

    public Vector3 start;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 8; i++)
            for (int j = 0; i < 8; i++)
                if (Random.Range(0, 1) > 0.7f)
                    theBroken[i, j] = true;

        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (Random.Range(0.0f, 1.0f) > 0.5f)
                    Instantiate<GameObject>(pre_Broken, new Vector3(thePos[j], start.y + (float)i * 4.5f), pre_Broken.transform.rotation);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
