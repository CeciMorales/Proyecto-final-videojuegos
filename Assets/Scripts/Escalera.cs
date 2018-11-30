using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalera : MonoBehaviour
{
    public float speed = 6;
    public Animator playerAnim;
    public bool isClimbing;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKey(KeyCode.W))
        {
            isClimbing = true;
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            playerAnim.SetBool("escaleras", true);
        }
        else if (collision.tag == "Player" && Input.GetKey(KeyCode.S))
        {

            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            playerAnim.SetBool("escaleras", true);
        }
        else if (collision.tag == "Player")
        {
            Debug.Log("SII");
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            collision.GetComponent<Rigidbody2D>().gravityScale = 0;
            playerAnim.SetBool("escaleras", false);
        }
    }
}
