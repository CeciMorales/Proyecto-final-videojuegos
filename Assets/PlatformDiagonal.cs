using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDiagonal  : MonoBehaviour
{

    float dirX;
    public float moveSpeed = 3f;
    bool moveRight = true;
    float initialPositiony;
    float initialPositionx;
    public float arriba;
    public float abajo;
    public float derecha;
    public float izquierda;


    // Use this for initialization
    void Start()
    {
        initialPositiony = transform.position.y;
        initialPositiony = transform.position.y;
        initialPositionx = transform.position.x;
        initialPositionx = transform.position.x;


    }

    // Update is called once per frame
    void Update()
    {


        if (transform.position.y > (initialPositiony + arriba) && transform.position.x >(initialPositionx + arriba))
        {
            moveRight = false;
        }
        if (transform.position.y < (initialPositiony - abajo) && transform.position.x < (initialPositionx - abajo))
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x+moveSpeed*Time.deltaTime, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed*Time.deltaTime, transform.position.y - moveSpeed * Time.deltaTime);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}

