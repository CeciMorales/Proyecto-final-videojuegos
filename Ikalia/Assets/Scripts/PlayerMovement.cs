using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Rigidbody2D playerRigidBody;
    public float speed = 7300.67f;
    public float jumpSpeed = 1050;
    private float moveInput; //detect wheather or not is left or right
    public Animator playerAnim;
    


    //jump
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsvalue;

    //animation-fall
    private bool justJumped;


    // Use this for initialization
    void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsvalue;
        justJumped = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        playerRigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRigidBody.velocity.y);
        if (Input.GetAxis("Horizontal") == 0)
        {
            playerAnim.SetBool("isWalking", false);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            playerAnim.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            playerAnim.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GetComponent<AudioSource>().Play();
            //playerAnim.SetBool("isJumping", true);
            playerAnim.SetTrigger("IsJumping");
            playerRigidBody.AddForce(Vector2.up * jumpSpeed);
            justJumped = true;
            //isGrounded = false;
            //playerAnim.SetTrigger("Jump");

        }

        if (justJumped == true)
        {

        }
       
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsvalue;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            playerRigidBody.velocity = Vector2.up * jumpSpeed;
            extraJumps--;



        }else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            playerRigidBody.velocity = Vector2.up * jumpSpeed;
        }


    }
}
