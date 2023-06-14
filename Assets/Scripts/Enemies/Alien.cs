using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : NPC
{
    public float health;
    public float speed;

    public Projectile shootPrefab;

    public float frequency;
    public float amplitude; 


    private void FixedUpdate()
    {
        rigidBody.AddForce(Vector2.right * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);



        float sinFloat = Mathf.Sin(Time.fixedTime * frequency) * amplitude;

        rigidBody.AddForce(Vector2.up * sinFloat, ForceMode2D.Force);
    }

    private void Move()
    {

    }

}
