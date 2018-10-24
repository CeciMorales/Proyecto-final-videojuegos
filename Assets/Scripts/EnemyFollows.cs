using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollows : MonoBehaviour {


    public float speed = 10;
    float initialPosition;
    private Transform target; //player
    public bool canMove;


    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        canMove = true;
        initialPosition = transform.position.x;

        
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x > (initialPosition + 4f))
        {
            canMove = false;
        }
        if (transform.position.x < (initialPosition - 4f))
        {
            canMove = true;
        }




        if (canMove)
        {
            if (Vector2.Distance(transform.position, target.position) < 8 && Vector2.Distance(transform.position, target.position) > 3)
            {
                //(from, to)
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            }

        }
     
     

            

	}

   
   
}
