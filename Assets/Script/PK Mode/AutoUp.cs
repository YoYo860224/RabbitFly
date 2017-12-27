using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoUp : MonoBehaviour
{

    public Transform player1;
    public Transform player2;

    public float maxSpeed;
    public float minSpeed;
    public float speed;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        addspeed();
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }

    void addspeed()
    {
        float higest = player1.position.y > player2.position.y ? player1.position.y : player2.position.y;
        if (Mathf.Abs(player1.position.y - player2.position.y) > 25)
            if (player1.position.y > player2.position.y)
                player2.GetComponent<PKlife>().GetHrut();
            else
                player1.GetComponent<PKlife>().GetHrut();
        else if (higest - transform.position.y > 15)
            speed = Mathf.Lerp(speed, maxSpeed, 1.0f * Time.deltaTime);
        else
            speed = Mathf.Lerp(speed, minSpeed, 1.0f * Time.deltaTime);
    }
}
