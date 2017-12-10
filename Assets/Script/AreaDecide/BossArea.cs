using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArea : MonoBehaviour {
    [Header("你可以加入任何進到 boss 畫面需要的事放到這個腳本")]
    [Space(30)]

    public GameObject Boss;
    public GameObject smotothCam;
    bool bossStage;

    // Use this for initialization
    void Start () {
        bossStage = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (bossStage)
        {
            GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.1f);
        }
	}


    void hasIn()
    {
        GetComponent<Collider2D>().isTrigger = false;
        GameObject.Find("Rabbit").GetComponent<Control>().canControl = true;
        Invoke("StartAIAIAI", 3.0f);
      //  Boss.GetComponent<bossAction>().startAI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Rabbit"))
        {
            bossStage = true;

            collision.GetComponent<Control>().canControl = false;
            Invoke("hasIn", 0.3f);
            smotothCam.GetComponent<CameraFollow>().TopDownOffset = -1;
        }
    }

    void StartAIAIAI()
    {
        Boss.GetComponent<bossAction>().startAI();
    }


}
