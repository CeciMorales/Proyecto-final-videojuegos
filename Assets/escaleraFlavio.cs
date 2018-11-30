using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escaleraFlavio : MonoBehaviour {

    //ESCALERAS
    public float speed;
    public float distance;
    public LayerMask whatsIsLadder;
    public bool isClimbing;
    public Rigidbody2D playerRigidBody;
    // Use this for initialization
    void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatsIsLadder);
        if (hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                isClimbing = true;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.S))
            {
                isClimbing = false;
            }
        }

        if (isClimbing == true)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.position.x, Input.GetAxisRaw("Vertical") * speed);
            playerRigidBody.gravityScale = 0;
        }
        else
        {
            playerRigidBody.gravityScale = 5;
        }
    }
}
