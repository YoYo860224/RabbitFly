using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PkCamara : MonoBehaviour {
    public Transform player1;
    public Transform player2;

    public Transform winner;
    public Transform loser;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (!winner)
        {
            FixedCameraFollowSmooth(GetComponent<Camera>(), player1, player2);
            transform.position = new Vector3(0, transform.position.y + 2.0f, -10);
            SetWinner();
        }
        else
        {
             //slow
            FocusWinner();
        }
    }

    public void SetWinner()
    {
        if (player1.Find("Main").gameObject.active == false)
        {
            winner = player2;
            Time.timeScale = 0.3f;
            Invoke("OpenFinish", 1.0f);
        }

        if (player2.Find("Main").gameObject.active == false)
        {
            winner = player1;
            Time.timeScale = 0.3f;
            Invoke("OpenFinish", 1.0f);
        }
    }

    public void OpenFinish()
    {
        GetComponent<UIcontroller>().openFinish();
        Time.timeScale = 1.0f;
    }

    public void FocusWinner()
    {
        float Smooth = 1.0f;
        transform.position = Vector3.Lerp(transform.position, new Vector3(winner.position.x, winner.position.y,-10.0f), Smooth * Time.deltaTime);
        //   if (GetComponent<Camera>().orthographicSize > 3)
        //       GetComponent<Camera>().orthographicSize -= 0.1f;
        GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, 3, Smooth * Time.deltaTime);

    }

    public void FixedCameraFollowSmooth(Camera cam, Transform t1, Transform t2)
    {
        // How many units should we keep from the players
        float zoomFactor = 1.5f;
        float followTimeDelta = 0.8f;

        // Midpoint we're after
        Vector3 midpoint = (t1.position + t2.position) / 2f;

        // Distance between objects
        float distance = (t1.position - t2.position).magnitude;

        // Move camera a certain distance
        Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;

        // Adjust ortho size if we're using one of those
        if (cam.orthographic)
        {
            // The camera's forward vector is irrelevant, only this size will matter
            if (distance > 5.0f)
                cam.orthographicSize = distance;
        }
        // You specified to use MoveTowards instead of Slerp
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);

        // Snap when close enough to prevent annoying slerp behavior
        if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
            cam.transform.position = cameraDestination;
    }
}
