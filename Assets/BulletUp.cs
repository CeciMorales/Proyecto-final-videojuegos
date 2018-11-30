using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUp : MonoBehaviour
{

    public float velX = 0f;
    float velY = 10f; //only horizontal direction
    Rigidbody2D rb;
    ParticleSystem particulas;


    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        particulas = GameObject.Find("BulletParticle").GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 3f);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Colmillo") ||
            collision.gameObject.CompareTag("Enemy") ||
            collision.gameObject.CompareTag("OlmecaRoja") ||
            collision.gameObject.CompareTag("Picos") ||
            collision.gameObject.CompareTag("pltMov") ||
            collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("Paredes"))
        {

            particulas.transform.position = transform.position;
            particulas.Play();
            Destroy(gameObject);

        }
    }
}
