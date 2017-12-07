using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAction : MonoBehaviour {
    public bool stateIsDone;
    public float fireBallSpeed = 10f;
    public int fireBallNumber;
    public float theRocketNumber;
    public float rocketAutoDisappear;
    public int hp;
    public int timeToUseSkill;
    public Camera mainCamera;
    public Animator anim;
    public GameObject fire;
    public GameObject fireBall;
    public GameObject rocket;
    public GameObject therocket;
    Vector3 originalCameraPosition;
    float shakeAmt = 0.1f;
    private BossActionType eCurState = BossActionType.idle;
    private BossActionType lastState = BossActionType.idle;


    // fortest 2 time 1 sleep
    int ttttttt = 0;

    public enum BossActionType
    {
        idle,
        sleeping,
        giveHurt,
        bossRocket,
        bossFire
    }


    // Use this for initialization
    void Start () {
        fire.SetActive(false);
        fireBall.SetActive(false);
        rocket.SetActive(false);
        therocket.SetActive(false);
        stateIsDone = true;
        startAI();

        //test for function
        //this.Invoke("attackRocket",3.0f);
        //this.Invoke("attackFire", 3.0f);
        //this.Invoke("Sleep", 1.0f);
        //this.Invoke("giveHurt",3.0f);
    }

    private void startAI()
    {
        if (eCurState == BossActionType.idle)
        {
            do
            {
                eCurState = (BossActionType)Random.Range(1, 5);
            } while (eCurState == lastState);

            // for test/////////////////////////////////
            ttttttt++;
            if (ttttttt == 1)
                eCurState = BossActionType.bossFire;
            if (ttttttt == 2)
                eCurState = BossActionType.sleeping;
            if (ttttttt == 3)
                eCurState = BossActionType.bossRocket;
            if (ttttttt == 4)
                eCurState = BossActionType.sleeping;
            ////////////////////////////////////////////

            switch (eCurState)
            {
                case BossActionType.giveHurt:
                    this.giveHurt();
                    break;
                case BossActionType.sleeping:
                    this.Sleep();
                    break;
                case BossActionType.bossFire:
                    this.attackFire();
                    break;
                case BossActionType.bossRocket:
                    this.attackRocket();
                    break;

            }
            lastState = eCurState;
            eCurState = BossActionType.idle;
        }
    }
	
    private void attackRocket()
    {
        rocket.SetActive(true);
        this.Invoke("rocketShoot", timeToUseSkill);
        originalCameraPosition = mainCamera.transform.position;
        this.InvokeRepeating("CameraShake", 0, 0.01f);
        this.Invoke("StopShaking", timeToUseSkill);
        anim.SetTrigger("ready");
    }

    private void rocketShoot()
    {
        rocket.SetActive(false);
        anim.SetTrigger("rocket");
        this.InvokeRepeating("rocketShooting", 0.1f, 1.5f);
        this.Invoke("stopRocket", 1.5f * theRocketNumber);
    }

    private void rocketShooting()
    {
        therocket.SetActive(false);
        GameObject rocketPrefab = Instantiate(therocket, therocket.transform.position, Quaternion.identity);
        rocketPrefab.transform.localScale = new Vector3(fireBall.transform.localScale.x * 0.3f, fireBall.transform.localScale.y * 0.3f, fireBall.transform.localScale.z * 0.3f);
        rocketPrefab.SetActive(true);
        StartCoroutine(rocketExplode(rocketPrefab, rocketAutoDisappear));
       // Invoke("rocketExplode",  rocketAutoDisappear);
    }

    IEnumerator rocketExplode(GameObject rocket, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        if(rocket)
            rocket.GetComponent<homingMissile>().Explode();
    }

    private void rocketExplode(GameObject rocket)
    {
        rocket.GetComponent<homingMissile>().Explode();
    }

    private void stopRocket()
    {
        CancelInvoke("rocketShooting");
        anim.SetTrigger("toIdle");
        ///AI
        startAI();
    }

    private void attackFire()
    {
        fire.SetActive(true);
        this.Invoke("fireShoot", timeToUseSkill);
        originalCameraPosition = Camera.main.transform.position;
        this.InvokeRepeating("CameraShake", 0, 0.01f);
        this.Invoke("StopShaking", timeToUseSkill);
        anim.SetTrigger("ready");
    }

    private void fireShoot()
    {
        fire.SetActive(false);
        anim.SetTrigger("fire");
        //originalCameraPosition = mainCamera.transform.position;
        this.InvokeRepeating("fireShooting", 0.1f, 1.0f);
        this.Invoke("stopFire", fireBallNumber);       
    }

    void fireShooting()
    {
        GameObject ballPrefab = Instantiate(fireBall, fireBall.transform.position, Quaternion.identity);
        ballPrefab.transform.localScale = new Vector3(fireBall.transform.localScale.x * 0.1f, fireBall.transform.localScale.y * 0.1f, fireBall.transform.localScale.z * 0.1f);
        ballPrefab.SetActive(true);
        Vector3 offset = GameObject.Find("Rabbit").transform.position - ballPrefab.transform.position;
        Debug.Log(offset);
        Vector3 direction = offset.normalized;
        float power = offset.magnitude;
        ballPrefab.GetComponent<Rigidbody2D>().AddForce(direction * power * fireBallSpeed);
    }

    void stopFire()
    {
        CancelInvoke("fireShooting");
        anim.SetTrigger("toIdle");
        ///AI
        startAI();
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
        //
        Invoke("startAI", 5.0f);
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
                            //Destroy(GetComponent<spriteChange>());
                            gameObject.layer = LayerMask.NameToLayer("DeadBody");
                            Time.timeScale = 0.3f; //slow motion for killing boss
                            anim.SetTrigger("dead");
                            this.Invoke("timeReset",1.0f);
                            Camera.main.GetComponent<UIcontroller>().openFinish();
                            
                        }
                        else
                        {
                            anim.SetTrigger("getHurt");
                            collision.gameObject.GetComponent<Control>().TopJump();
                            this.Invoke("startAI", 3.0f);
                        }                                                      
                    }
                    else // down
                        collision.gameObject.GetComponent<RabbitInfo>().GetHrut();
                }
                else if (!currentState.IsName("getHurt"))
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
        Vector3 pp = Camera.main.transform.position;
        pp.x += quakeAmt;
        Camera.main.transform.position = pp;
    }

    void StopShaking()
    {
        CancelInvoke("CameraShake");
        Vector3 pp = Camera.main.transform.position;
        pp.x = 0;
        Camera.main.transform.position = pp;
    }

    // Update is called once per frame

}
