using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitInfo : MonoBehaviour
{
    public GameObject camare_toReset;
    public GameObject smoothpos_toReset;

    public int maxLife;
    public int life;

    public static RabbitInfo
    Instance;
    // Use this for initialization
    void Start()
    {
        life = maxLife;
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Restart();
        }
    }

    void Restart()
    {
        transform.position = new Vector3(-7.79f, 1.29f, 0);
        smoothpos_toReset.transform.position = new Vector3(0, 0, 0);
        camare_toReset.transform.position = new Vector3(0, 0, -10);         
        life = maxLife;
        GetComponent<Control>().enabled = true;
        transform.Find("Main").gameObject.SetActive(true);
        transform.Find("Foot").gameObject.SetActive(true);
        transform.Find("DeadBody").gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            if (life > 1)
            {
                life--;
                UIcontroller.UIcontroll.lifeMinus();//扣血UI
            }
            else
            {
                life--;
                UIcontroller.UIcontroll.lifeMinus();//扣血UI
                GetComponent<Control>().enabled = false;
                transform.Find("Main").gameObject.SetActive(false);
                transform.Find("Foot").gameObject.SetActive(false);
                transform.Find("DeadBody").gameObject.SetActive(true);
            }
        }
    }
}
