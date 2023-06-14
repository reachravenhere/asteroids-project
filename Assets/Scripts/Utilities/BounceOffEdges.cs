using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BounceOffEdges : MonoBehaviour
{
    public float minimumBound = 0.1f;
    public float maximumBound = 0.9f;
    public float bounceMultiplier = 1.25f;

    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody.drag <= 0f)
        {
            bounceMultiplier = 1f;
        }
    }

    private void FixedUpdate()
    {
        Bounce();   
    }
    private void Bounce()
    {
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        if (position.x < minimumBound)
        {
            rigidBody.velocity = Vector3.Reflect(rigidBody.velocity * bounceMultiplier, Vector3.right);


        }
        if (position.x > maximumBound)
        {
            rigidBody.velocity = Vector3.Reflect(rigidBody.velocity * bounceMultiplier, Vector3.left);

        }
        if (position.y < minimumBound)
        {
            rigidBody.velocity = Vector3.Reflect(rigidBody.velocity * bounceMultiplier, Vector3.up);
        }
        if (position.y > maximumBound)
        {

            rigidBody.velocity = Vector3.Reflect(rigidBody.velocity * bounceMultiplier, Vector3.down);
        }
    }
}
