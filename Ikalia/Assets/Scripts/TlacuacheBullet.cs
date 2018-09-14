using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TlacuacheBullet : MonoBehaviour {

    public float ballSpeed;
    private Rigidbody2D theRB;

    public GameObject ballEffect;

   

	// Use this for initialization
	void Start () {

        theRB = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

        //direction
        theRB.velocity = new Vector2(ballSpeed*transform.localScale.x, 0f);
		

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        //when bullet interacts with other collider 2d
        if (other.gameObject.tag  != "Player")
        {
            Instantiate(ballEffect, transform.position, transform.rotation);
            Destroy(gameObject);

        }
        
        

        
    }
}
