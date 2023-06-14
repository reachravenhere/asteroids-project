using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : NPC
{
    
    public float driftSpeed;
    public List<Asteroid> spawns= new List<Asteroid>();
  

    
    protected override void Awake()
    {
        base.Awake();
        SetupMotion();

        

    }

    private void Start()
    {
        if(spawnVFX == null)
        {
            return;
        }

        GameObject activeVFX = Instantiate(spawnVFX, transform.position, transform.rotation);
        Destroy(activeVFX, 2f);
    }

    public void SetupMotion() 
    {
        Vector2 driftDirection = (Random.insideUnitCircle * (Vector2)transform.position).normalized * driftSpeed;
        rigidBody.velocity = driftDirection;

        float randomSpin = Random.Range(-360f, 360f);
        rigidBody.angularVelocity = randomSpin;
    }
    

    
    private void SpawnBabies()
    {
        //Debug.Log("count of babies : " + spawns.Count);
        for (int i = 0; i < spawns.Count; i++)
        {
            Instantiate(spawns[i], transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player Bullet")
        {
            SpawnBabies();
            Die();
        }
    }

    

}
