using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNivel2 : MonoBehaviour
{
    public GameObject BulletEmissor;
    public GameObject BulletEmissor2;
    public int health = 30;
    public GameObject Bala;
    public bool bossHit;
    public double timeLeft = 1;

    //MOVER
    /*public Transform MinimumBoundary;
    public Transform MaxBoundary;
    public float Speed = 10;*/


    float dirX, moveSpeed = 10f;
    bool moveRight = true;
    float initialPosition;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Shoot", 0.45f, 1.6f);
        InvokeRepeating("Shoot2", 1.15f, 1.6f);

        initialPosition = transform.position.x;
        Debug.Log(health);
        bossHit = false;
       

}

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > (initialPosition + 30f))
        {
            moveRight = false;
        }
        if (transform.position.x < (initialPosition - 30f))
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
        returnBossHit();
        /*
        



        Transform currentTransform = transform;

        float horizontal = Speed * Time.deltaTime;

        currentTransform.Translate(Vector2.right * horizontal);
        
        float x = Mathf.Clamp(currentTransform.position.x,
                              MinimumBoundary.position.x,
                              MaxBoundary.position.x);
        

        currentTransform.position = new Vector2(x, currentTransform.position.y);

        transform.position = currentTransform.position;
        */
    }
    void Shoot()
    {
        Instantiate(Bala, BulletEmissor.transform.position, Quaternion.identity);
    }

    void Shoot2()
    {

        Instantiate(Bala, BulletEmissor2.transform.position, Quaternion.identity);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rollo"))
        {
            health = health - 1;
            colorBossHit();

            destroyBoss();

        }
        else if (collision.gameObject.CompareTag("TlacuacheRabia"))
        {
            health = health - 5;
            colorBossHit();
            destroyBoss();

        }
        else if (collision.gameObject.CompareTag("TlacuacheAtaca"))
        {
            health = health - 3;
            colorBossHit();
            destroyBoss();
        }



    }

    public void destroyBoss()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void colorBossHit()
    {

        GetComponent<SpriteRenderer>().color = new Color32(255, 190, 210, 255);
        bossHit = true;


    }
    void returnBossHit()
    {
        if (bossHit)
        {

            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                bossHit = false;
                GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

            }
        }
        else
        {
            timeLeft = 1;

        }

    }
}
