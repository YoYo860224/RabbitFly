using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAction : MonoBehaviour {
    public int hp;
    public Camera mainCamera;
    public Animator anim;
    Vector3 originalCameraPosition;
    float shakeAmt = 0.05f;


    // Use this for initialization
    void Start () {
        //test for function
        this.Invoke("Sleep", 1.0f);
      //  this.Invoke("giveHurt",3.0f);
	}
	
    private void Sleep()
    {
        anim.SetTrigger("setSleeping");
        ///for (int i = 0; i < 70; i++)
           // this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 0.01f);
    }

    private void giveHurt()
    {
        anim.SetTrigger("giveHurt");
        originalCameraPosition = mainCamera.transform.position;
        InvokeRepeating("CameraShake", 0, 0.01f);
        Invoke("StopShaking", 5.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Rabbit"))
        {
            if (collision.gameObject.name == "Rabbit" || collision.gameObject.name == "Foot")
            {
                AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
                if (currentState.IsName("sleeping") || currentState.IsName("sleeped"))
                {
                    if (collision.transform.Find("Main").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("down")) //down
                    {
                        hp--;
                        if (hp <= 0)
                        {
                            Destroy(GetComponent<spriteChange>());
                            Time.timeScale = 0.3f; //slow motion for killing boss
                            anim.SetTrigger("dead");
                            this.Invoke("timeReset",1.0f);
                        }
                            
                        else
                            anim.SetTrigger("getHurt");

                            
                    }
                    else // down
                        collision.gameObject.GetComponent<RabbitInfo>().GetHrut();
                }
                else
                    collision.gameObject.GetComponent<RabbitInfo>().GetHrut();
            }
        }
    }
    private void timeReset()
    {
        Time.timeScale = 1.0f;
    }

    void CameraShake()
    {
        float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
        Vector3 pp = mainCamera.transform.position;
        pp.x += quakeAmt;
        mainCamera.transform.position = pp;
    }

    void StopShaking()
    {
        CancelInvoke("CameraShake");
        mainCamera.transform.position = originalCameraPosition;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
