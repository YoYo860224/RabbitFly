using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class homingMissile : MonoBehaviour {
    public Transform target;
    public float rocketSpeed = 5f;
    public float rotateSpeed = 200f;
    private Rigidbody2D rb;
    GameObject prefab;
    public GameObject explosionEffect;
	// Use this for initialization
	void Start () {
        
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

    void OnCollisionEnter2D()
    {
        Explode();
    }
}
