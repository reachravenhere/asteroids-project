using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("Scoring")]
    public float pointValue;

    [Header("VFX")]
    public GameObject deathVFX;
    public GameObject spawnVFX;


    protected Rigidbody2D rigidBody;

    protected virtual void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
       

        GameManager.RegisterEnemy(this); 
    }



    protected virtual void Die()
    {
        GameObject activeVFX = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(activeVFX, 2f);

        Player.playerInstance.ScoreUpdate(pointValue);

        GameManager.UnregisterEnemy(this);



        Destroy(gameObject);
    }

}
