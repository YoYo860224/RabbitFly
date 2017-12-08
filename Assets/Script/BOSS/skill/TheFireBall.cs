using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFireBall : MonoBehaviour {
    Vector3 target_direct;
    public float lifeTime = 10.0f;
    public float speed;

    public void Start()
    {
        target_direct = GameObject.Find("Rabbit").transform.position - transform.position;
        target_direct.Normalize();
        Destroy(gameObject, lifeTime);
    }

    public void Update()
    {
        transform.position += target_direct * speed * Time.deltaTime;
    }

    public void SetSpeed(float theSpeed)
    {
        speed = theSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Rabbit"))
        {
            collision.gameObject.GetComponent<RabbitInfo>().GetHrut();
            Destroy(this.gameObject);
        }
    }
}
