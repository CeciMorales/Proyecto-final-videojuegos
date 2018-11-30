using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformVertical : MonoBehaviour {

    float dirX;
    public float moveSpeed = 3f;
    bool moveRight = true;
    float initialPosition;
    public float arriba;
    public float abajo;

    // Use this for initialization
    void Start()
    {
        initialPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        
            if (transform.position.y > (initialPosition + arriba))
            {
                moveRight = false;
            }
            if (transform.position.y < (initialPosition - abajo))
            {
                moveRight = true;
            }

            if (moveRight)
            {
                transform.position = new Vector2(transform.position.x , transform.position.y + moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
            }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
