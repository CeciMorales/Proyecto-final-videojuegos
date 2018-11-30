using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjoloteMovement : MonoBehaviour
{

    Rigidbody2D enemyRb;
    float timeBeforeChange = 0 ;
    public float delay;
    public float speed;
    //SpriteRenderer enemySpriteRend;

    //Animator enemyAnim;
    public ParticleSystem splash;
    public GameObject part;
    private int bulletsCount;
    public bool enemyHit;
   
    public AudioSource movementAudio;
    public AudioSource deadAudio;


    // Use this for initialization
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        //enemyAnim = GetComponent<Animator>();
        //enemySpriteRend = GetComponent<SpriteRenderer>();
        splash.Play();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.velocity = Vector2.right * speed;

        splash.transform.position = transform.position;
        
        /*if (speed > 0)
        {
            enemySpriteRend.flipX = false;

        }
        else if (speed < 0)
        {
            enemySpriteRend.flipX = true;
        }*/
        if (timeBeforeChange < Time.time || timeBeforeChange ==0) //tiempo desde que empezo la app
        {
            speed *= -1; //cambiar direccion
            timeBeforeChange = Time.time + delay;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Rollo"))
        {
            
            bulletsCount++;

            colorPlayerHit();
            //moveEnemyHit();
            movementAudio.Stop();
            deadAudio.Play();

            if (bulletsCount == 5)
            {
                
                Destroy(gameObject);
                part.SetActive(false);

            }

        }

    }

    public void DisableEnemy()
    {
        gameObject.SetActive(false);
    }

    void colorPlayerHit()
    {

        GetComponent<SpriteRenderer>().color = new Color32(255, 190, 210, 255);
        enemyHit = true;


    }
}
