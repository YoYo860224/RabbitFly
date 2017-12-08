using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TheRocket : MonoBehaviour {
    public Transform target;
    public float rocketSpeed = 5f;
    public float rotateSpeed = 200f;
    private Rigidbody2D rb;
    GameObject prefab;
    public GameObject explosionEffect;
	// Use this for initialization
	void Start () {
        target = GameObject.Find("Rabbit").transform;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.right).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.right * rocketSpeed;
	}

    public void Explode()
    {

        prefab = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(prefab, 2f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Rabbit"))
        {
            collision.gameObject.GetComponent<RabbitInfo>().GetHrut();
        }
        Explode();
    }
}
