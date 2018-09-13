using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    
    Rigidbody2D enemyRb;
    float timeBeforeChange;
    public float delay = 1.9f;
    public float speed = 1.8f;
    SpriteRenderer enemySpriteRend;
   
    Animator enemyAnim;

   
    // Use this for initialization
    void Start () {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        enemySpriteRend = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        enemyRb.velocity = Vector2.right * speed;

        if (speed > 0)
        {
            enemySpriteRend.flipX = false;

        }
        else if (speed < 0)
        {
            enemySpriteRend.flipX = true;
        }
        if (timeBeforeChange < Time.time) //tiempo desde que empezo la app
        {
            speed *= -1; //cambiar direccion
            timeBeforeChange = Time.time + delay;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            HealthBar.health -= 10f;
            if (transform.position.y  < collision.transform.position.y)
            {
                enemyAnim.SetBool("isDead", true);
                
            }
        }

    }

    public void DisableEnemy()
    {
        gameObject.SetActive(false);
    }
}
