using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player playerInstance;

    public float thrustForce;
    public float rotationSpeed;
    public float shotCooldown;
    public float score;
    public Projectile bullet;
    public Rigidbody2D shiprigidBody;
    public ParticleSystem thrustParticles;
    public GameObject deathVfx;

    private float nextFireTime;
    private HUD hud;


    private void Awake()
    {
        if(playerInstance == null)
        {
            playerInstance = this;
        }

        hud = FindObjectOfType<HUD>();
        
    }

    private void Update()
    {
       HandleParticles();
       GetFireInput();
    }



    private void FixedUpdate()
    {
       
        Rotate();
        AddThrust();
    }

    private void GetFireInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
    }

    private void Rotate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        float turningValue = -horizontal * rotationSpeed * Time.fixedDeltaTime;
        shiprigidBody.AddTorque(turningValue);
    }
    private void AddThrust()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 thrustValue = transform.up*vertical* thrustForce* Time.fixedDeltaTime;


        shiprigidBody.AddForce(thrustValue);
    }
    private void Shoot()
    {
        Projectile activeShot = Instantiate(bullet, transform.position, transform.rotation);

        

        AudioManager.instance.PlaySound("Zap");
    }
    private void Die()
    {
        GameObject activeVfx = Instantiate(deathVfx,transform.position,Quaternion.identity);
        Destroy(activeVfx, 2f);

        //EndGamePanel endGamePanel = FindObjectOfType<EndGamePanel>();

        //endGamePanel.Open();
        //endGamePanel.Setup(true);

        PanelManager.OpenPanel<EndGamePanel>().Setup(true);

        GameManager.gameManagerInstance.ResetGame();

        Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided With: " + collision.gameObject.name);

        if (collision.gameObject.tag == "Enemy")
        {
            Die();
        }
    }

    private void HandleParticles()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        if (vertical > 0f)
        {
            if(thrustParticles.isPlaying == false)
            {
                thrustParticles.Play();
            }
        }
        else
        {
            if(thrustParticles.isPlaying ==true)
            {
                thrustParticles.Stop();
            }
        }

    }
    

    public void ScoreUpdate(float scoreToAdd)
    {
        score += scoreToAdd;

        hud.SetScoreText("Score: " + score);

        LootManager.AddToThreshold(scoreToAdd);

    }

}