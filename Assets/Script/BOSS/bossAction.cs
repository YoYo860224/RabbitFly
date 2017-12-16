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

    [Header("Lasor")]

    public int perLasorNum;
    public float perLasorTime;
    public float allLasorTime;
    public float LasorReady;
    public float LasorStay;

    public GameObject lasorIcon;
    public GameObject lasor_prefab;
    public GameObject lasor_position;

    private BossActionType eCurState = BossActionType.idle;
    private BossActionType lastState = BossActionType.idle;


    // fortest 2 time 1 sleep
    int ttttttt = 0;

    public enum BossActionType
    {
        idle,
        sleeping,
        bossRocket,
        bossFire,
        bossLasor
    }

    // Use this for initialization
    void Start () {
        fireIcon.SetActive(false);
        rocketIcon.SetActive(false);
        hp = max_hp;

        //startAI();
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
                eCurState = BossActionType.bossLasor;
            if (ttttttt == 2)
                eCurState = BossActionType.bossFire;
            if (ttttttt == 3)
                eCurState = BossActionType.sleeping;
            if (ttttttt == 4)
                eCurState = BossActionType.bossRocket;
            if (ttttttt == 5)
                eCurState = BossActionType.sleeping;
            ////////////////////////////////////////////

            switch (eCurState)
            {
                case BossActionType.sleeping:
                    Sleep();
                    break;
                case BossActionType.bossFire:
                    ReadyFire();
                    break;
                case BossActionType.bossLasor:
                    ReadyLasor();
                    break;              
                case BossActionType.bossRocket:
                    ReadyRocket();
                    break;
            }
            lastState = eCurState;
            eCurState = BossActionType.idle;
        }
    }

    // rocket
    #region rocket
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
    #endregion

    // fireBall
    #region fire

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

    #endregion

    // laosr
    #region lasor

    private void ReadyLasor()
    {
        lasorIcon.SetActive(true);
        anim.SetTrigger("ready");
        Invoke("UsingLasor", readyTime);
    }

    private void UsingLasor()
    {
        anim.SetTrigger("lasor");
        InvokeRepeating("MakeLasor", 0.1f, perLasorTime);
        Invoke("StopLasor", allLasorTime);
    }

    private void MakeLasor()
    {
        // Don't Mind Just for focus Rabbit , but my Math is bad , use force mathod to solve this problem
        // and the variable is set free dont mind. so this code is dirty

        Vector3 target = GameObject.Find("Rabbit").transform.position;
        Vector3 a = target - lasor_position.transform.position;
        GameObject lasorPrefab_toR = Instantiate(lasor_prefab, lasor_position.transform.position, 
            Quaternion.Euler(0, 0, Mathf.Atan2(a.y ,a.x) * 180.0f / 3.14f + 180.0f));
        lasorPrefab_toR.transform.Find("BossVer").GetComponent<TheLasor>().Set(LasorReady, LasorStay);

        for (int i = 1; i < perLasorNum; i++)
        {
            float rotatef = Random.Range(-200.0f, 30.0f);
            GameObject lasorPrefab = Instantiate(lasor_prefab, lasor_position.transform.position, Quaternion.Euler(0, 0, rotatef));
            lasorPrefab.transform.Find("BossVer").GetComponent<TheLasor>().Set(LasorReady, LasorStay);
        }
    }

    private void StopLasor()
    {
        Invoke("WaitToLide", LasorReady + LasorStay);
        CancelInvoke("MakeLasor");

        ///AI
        startAI();
    }

    private void WaitToLide()
    {
        lasorIcon.SetActive(false);
        anim.SetTrigger("toIdle");
    }
    #endregion


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
