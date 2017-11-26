using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabbitInfo : MonoBehaviour
{
    public GameObject camare_toReset;
    public GameObject smoothpos_toReset;
    //[SerializeField] LayerMask whatIsDead;

    public int maxLife;
    public int life;

    public int combo;
    public Text comboText;

    public float hurtTime = 1.0f;

    int count_shine;
    bool no_hurt = false;

    public Animator anim;

    public static RabbitInfo
    Instance;
    // Use this for initialization
    void Start()
    {
        life = maxLife;
        Instance = this;

        anim = transform.Find("Main").GetComponent<Animator>();  //  Get From Public
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Restart();
        }

        if (count_shine >= hurtTime / 0.2f )
        {
            CancelInvoke();
            no_hurt = false;
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

    public void GetHrut()
    {
        if (!no_hurt)
        {
            no_hurt = true;

            if (life > 1)    // 還有血量
            {
                life--;                                 // 實際扣血
                UIcontroller.UIcontroll.lifeMinus();    // 扣血UI
                ResetCombo();

                // 受傷一閃一閃       
                count_shine = 0;
                InvokeRepeating("Shine_Transparent", 0.0f, 0.2f);

                // 受傷彈跳
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("down"))
                {
                    transform.gameObject.GetComponent<Control>().TopJump();
                }
                else if (anim.GetCurrentAnimatorStateInfo(0).IsName("roundR"))
                {
                    transform.gameObject.GetComponent<Control>().jumpR();
                }
                else if (anim.GetCurrentAnimatorStateInfo(0).IsName("roundL"))
                {
                    transform.gameObject.GetComponent<Control>().jumpL();
                }
                else
                {
                    transform.gameObject.GetComponent<Control>().TopJump();
                }

            }
            else  // 死亡
            {
                life--;
                UIcontroller.UIcontroll.lifeMinus();    //扣血UI
                ResetCombo();

                // 死亡動畫
                GetComponent<Control>().enabled = false;
                transform.Find("Main").gameObject.SetActive(false);
                transform.Find("Foot").gameObject.SetActive(false);
                transform.Find("DeadBody").gameObject.SetActive(true);

                // 跳死亡選單
                {

                }
            }
        }
        else
        {
            gameObject.GetComponent<Control>().SetGround(true);
            Invoke("ReturnFalse", 0.1f);
        }

    }

    // for invoke return 
    private void ReturnFalse()
    {
        gameObject.GetComponent<Control>().SetGround(false);
    }

    // 一閃一閃亮晶晶
    private void Shine_Transparent()
    {
        transform.Find("Main").gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 0);
        Invoke("Shine_White", 0.1f);
    }
    private void Shine_White()
    {
        transform.Find("Main").gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        count_shine++;
    }


    // for combo
    public void AddCombo()
    {
        combo++;
        comboText.enabled = true;
        comboText.text = combo.ToString() + " Combo !!!!";
        this.Invoke("disapearCombo", 1.5f);
    }
    public void ResetCombo()
    {
        combo = 0;
    }

    private void disapearCombo()
    {
        comboText.enabled = false;
    }

    // allllll collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Trap"))
        {  
            GetHrut();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Trap"))
        {
            GetHrut();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            GetHrut();
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            GetHrut();
        }
    }



}
