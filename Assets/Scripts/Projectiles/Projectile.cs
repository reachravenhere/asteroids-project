using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float moveSpeed;
    public float lifetime = 2f;


    private Rigidbody2D myRigidbody;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveForce = transform.up * moveSpeed * Time.fixedDeltaTime;
        myRigidbody.AddForce(moveForce);
    }


    private void OnTriggerEnter2D (Collider2D collision) {

        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    
    }
    
}
