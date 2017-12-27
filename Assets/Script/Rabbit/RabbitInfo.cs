using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabbitInfo : MonoBehaviour
{
    Animator anim;

    [Header("Life Info")]
    public int maxLife;
    public int life;

    [Header("Hurt Info")]
    public float hurtTime = 1.0f;
    int  count_shine;
    bool no_hurt = false;

    [Header("Combo Info")]
    public int combo;

    void Start()
    {
        life = maxLife;

        anim = transform.Find("Main").GetComponent<Animator>();
    }

    void Update()
    {
        if (count_shine >= hurtTime / 0.2f )
        {
            CancelInvoke();
            no_hurt = false;
        }
    }

    // if no hurt will return false
    public bool GetHrut()
    {
        if (!no_hurt)       // 非受傷無敵狀態
        {
            no_hurt = true;                         // 開啟無敵
            ResetCombo();                           // 取消 Combo
            life--;                                 // 實際扣血
            UIcontroller.UIcontroll.lifeMinus(life);    // 扣血UI

            if (life > 0)   // 還有血量
            {
                // 受傷一閃一閃       
                count_shine = 0;
                InvokeRepeating("Shine_Transparent", 0.0f, 0.2f);
                transform.Find("hurt_sound").GetComponent<AudioSource>().Play();

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
            else // 已死亡
            {
                // 死亡動畫
                GetComponent<Control>().enabled = false;
                Destroy(GetComponent<Rigidbody2D>());
                transform.Find("Main").gameObject.SetActive(false);
                transform.Find("Foot").gameObject.SetActive(false);
                transform.Find("DeadBody").gameObject.SetActive(true);
            }
            return true;
        }
        else // 是受傷無敵狀態
        {
            return false;
        }
    }

    // 受傷之一閃一閃亮晶晶
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
        transform.Find("getPoint_sound").GetComponent<AudioSource>().Play();      
        UIcontroller.UIcontroll.SetCombo(combo);
    }
    public void ResetCombo()
    {
        if (combo > 0)
        {
            combo = 0;
            UIcontroller.UIcontroll.SetCombo(combo);
        }
    }

    // all collider 關於 trap
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("nt_ColliderTrap"))
        {
            GetHrut();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {      
        if (collision.gameObject.layer == LayerMask.NameToLayer("nt_ColliderTrap"))
        {
            GetHrut();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("nt_TriggerTrap"))
        {
            GetHrut();
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("nt_TriggerTrap"))
        {
            GetHrut();
        }
    }
}
