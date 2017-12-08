using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAction : MonoBehaviour {
    public Animator anim;

    [Header("Info")]
    public int max_hp;
    public int hp;
    public int readyTime;
    public float weakTime = 2.0f;
    bool weakState;

    [Header("Skill_Rocket")]
    public float rocketSpeed = 5.0f;
    public float rocketLifeTime = 10.0f;
    public float perRocketTime;
    public float allRocketTime;

    public GameObject rocketIcon;
    public GameObject rocket_prefab;
    public GameObject rocket_position;

    [Header("Skill_FireBall")]
    public float fireBallSpeed = 5.0f;
    public float perFireBallTime;
    public float allFireBallTime;

    public GameObject fireIcon;
    public GameObject fireBall_prefab;
    public GameObject fireBall_position;



    private BossActionType eCurState = BossActionType.idle;
    private BossActionType lastState = BossActionType.idle;


    // fortest 2 time 1 sleep
    int ttttttt = 0;

    public enum BossActionType
    {
        idle,
        sleeping,
        bossRocket,
        bossFire
    }


    // Use this for initialization
    void Start () {
        fireIcon.SetActive(false);
        rocketIcon.SetActive(false);
        hp = max_hp;

        //startAI();

        //test for function
        //this.Invoke("attackRocket",3.0f);
        //this.Invoke("attackFire", 3.0f);
        //this.Invoke("Sleep", 1.0f);
        //this.Invoke("giveHurt",3.0f);
    }

    public void startAI()
    {
        if (eCurState == BossActionType.idle)
        {
            do
            {
                eCurState = (BossActionType)Random.Range(1, 4);
            } while (eCurState == lastState);

            // for test/////////////////////////////////
            ttttttt++;
            if (ttttttt == 1)
                eCurState = BossActionType.bossRocket;
            if (ttttttt == 2)
                eCurState = BossActionType.bossFire;
            if (ttttttt == 3)
                eCurState = BossActionType.sleeping;
            ////////////////////////////////////////////

            switch (eCurState)
            {
                case BossActionType.sleeping:
                    this.Sleep();
                    break;
                case BossActionType.bossFire:
                    this.ReadyFire();
                    break;
                case BossActionType.bossRocket:
                    this.ReadyRocket();
                    break;
            }
            lastState = eCurState;
            eCurState = BossActionType.idle;
        }
    }

    // rocket

    private void ReadyRocket()
    {
        rocketIcon.SetActive(true);
        anim.SetTrigger("ready");
        Invoke("UsingRocket", readyTime);
    }

    private void UsingRocket()
    {
        anim.SetTrigger("rocket");
        InvokeRepeating("MakeRocket", 0.1f, perRocketTime);
        Invoke("StopRocket", allRocketTime);
    }

    private void MakeRocket()
    {
        GameObject rocketPrefab = Instantiate(rocket_prefab, rocket_position.transform.position, Quaternion.identity);
        StartCoroutine(rocketExplode(rocketPrefab, rocketLifeTime));
    }

    IEnumerator rocketExplode(GameObject rocket, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        if (rocket)
            rocket.GetComponent<TheRocket>().Explode();
    }

    private void rocketExplode(GameObject rocket)
    {
        rocket.GetComponent<TheRocket>().Explode();
    }

    private void StopRocket()
    {
        rocketIcon.SetActive(false);
        anim.SetTrigger("toIdle");
        CancelInvoke("MakeRocket");
       
        ///AI
        startAI();
    }

    // fireBall

    private void ReadyFire()
    {
        fireIcon.SetActive(true);       
        anim.SetTrigger("ready");
        Invoke("UsingFire", readyTime);
    }

    private void UsingFire()
    {
        anim.SetTrigger("fire");
        InvokeRepeating("MakeFire", 0.1f, perFireBallTime);
        Invoke("StopFire", allFireBallTime);       
    }

    void MakeFire()
    {
        GameObject ballPrefab = Instantiate(fireBall_prefab, fireBall_position.transform.position, Quaternion.identity);
        ballPrefab.GetComponent<TheFireBall>().SetSpeed(fireBallSpeed);      
    }

    void StopFire()
    {
        fireIcon.SetActive(false);
        anim.SetTrigger("toIdle");
        CancelInvoke("MakeFire");

        ///AI
        startAI();
    }

    private void Finish()
    {
        Time.timeScale = 1.0f;
        GameObject.Find("UI").GetComponent<UIcontroller>().openWin();
    }

    private void Sleep()
    {
        anim.SetTrigger("setSleeping");
    }

    // 受傷之類的
    private void GetHurt(Collision2D collision)
    {
        hp--;
        if (hp > 0)
        {
            anim.SetTrigger("getHurt");
            collision.gameObject.GetComponent<Control>().TopJump();

            weakState = true;
            InvokeRepeating("Shine_Transparent", 0.0f, 0.2f);
            Invoke("CancelWeak", weakTime);

            this.Invoke("startAI", 3.0f);
        }
        else
        {
            Dead();
        }
    }

    private void Dead()
    {
        gameObject.layer = LayerMask.NameToLayer("DeadBody");
        anim.SetTrigger("dead");
        Time.timeScale = 0.3f;          //slow motion for killing boss       
        this.Invoke("Finish", 1.0f);    //will Return in here
    }

    // 虛弱之一閃一閃亮晶晶
    private void CancelWeak()
    {
        CancelInvoke("Shine_Transparent");
        CancelInvoke("Shine_White");
        weakState = false;
    }

    private void Shine_Transparent()
    {
       GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 0);
        Invoke("Shine_White", 0.1f);
    }
    private void Shine_White()
    {
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Rabbit"))
        {
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (currentState.IsName("sleeping") || currentState.IsName("sleeped"))      // 在睡覺才會受傷
            {
                if (collision.transform.Find("Main").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("down")) // 要向下衝才會受傷
                {
                    GetHurt(collision);
                }
                else // down
                {
                    if (!weakState)
                        if (!collision.gameObject.GetComponent<RabbitInfo>().GetHrut())
                            collision.gameObject.GetComponent<Control>().TopJump();
                }
            }
            else if (!weakState)
            {
                if (!collision.gameObject.GetComponent<RabbitInfo>().GetHrut())
                    collision.gameObject.GetComponent<Control>().TopJump();
            }
            else
            {
                collision.gameObject.GetComponent<Control>().TopJump();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Rabbit"))
        {
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (currentState.IsName("sleeping") || currentState.IsName("sleeped"))      // 在睡覺才會受傷
            {
                if (collision.transform.Find("Main").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("down")) // 要向下衝才會受傷
                {
                    GetHurt(collision);
                }
                else // down
                {
                    if (!weakState)
                        if (!collision.gameObject.GetComponent<RabbitInfo>().GetHrut()) // 非受傷狀態會 return false
                            collision.gameObject.GetComponent<Control>().TopJump();     // 所以讓他跳一下 不會停在那
                }
            }
            else if (!weakState)
            {
                if (!collision.gameObject.GetComponent<RabbitInfo>().GetHrut())
                    collision.gameObject.GetComponent<Control>().TopJump();
            }
            else
            {
                collision.gameObject.GetComponent<Control>().TopJump();                 // 他一閃一閃的時候不要讓兔子 馬上受傷 也讓他跳一下 不會停在那
            }
        }
    }

}
