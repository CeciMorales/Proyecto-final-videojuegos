using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimplerPlayerMov : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;
    public float speed = 15f;
    public float jumpSpeed = 50;

    private float moveInput; //detect wheather or not is left or right
    public Animator playerAnim;



    //jump
    public bool isGrounded;
    public bool isMoving;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public static bool isFlip;

    private int extraJumps;
    public int extraJumpsvalue;

    //animation-fall
    // private bool justJumped;

    //BULLET
    public GameObject rolloRight;
    public GameObject rolloLeft;
    public Vector2 bulletPos;
    public float fireRate = 0.5f; //one bullet in half sec
    public float nextFire = 0.0f; //count time from the last bullet

    public GameObject tlacuacheRabia;
    public GameObject tlacuacheAtaca;

    private int numTlacuachesRabia;
    private int numTlacuachesAtaca;

    private int countTlacuachesRabia;
    private int countTlacuachesAtaca;



    

    //tlacuaches
    public bool activateTlacuaches;

   

    public bool canMove;


    public AudioSource moneda;
    public AudioSource soundBala;


    // Use this for initialization
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsvalue;
        isFlip = false;

        canMove = true;

        activateTlacuaches = false;

        countTlacuachesRabia = 0;
        countTlacuachesAtaca = 0;

        isMoving = false;
        isGrounded = true;


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        playerRigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRigidBody.velocity.y);


        if (Input.GetAxis("Horizontal") == 0)
        {

            playerAnim.SetBool("isWalking", false);
            isMoving = false;



        }
        else
        {
            isMoving = true;

        }

        if (Input.GetAxis("Horizontal") < 0 && canMove)
        {


            playerAnim.SetBool("isWalking", true);

            GetComponent<SpriteRenderer>().flipX = true;

            isFlip = true;
            isMoving = true;



        }
        else if (Input.GetAxis("Horizontal") > 0 && canMove)
        {

            playerAnim.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = false;
            isFlip = false;
            isMoving = true;

        }
        else
        {
            isMoving = false;
        }



        if (Input.GetKeyDown(KeyCode.Space) && canMove)
        {
            
            playerAnim.SetTrigger("IsJumping");
            playerRigidBody.AddForce(Vector2.up * jumpSpeed);
            
            isGrounded = false;
            isMoving = true;


        }
        else
        {
            isMoving = false;
        }




    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsvalue;
            playerAnim.SetTrigger("idle");
            playerAnim.SetBool("escaleras", false);

        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            playerRigidBody.velocity = Vector2.up * jumpSpeed;
            extraJumps--;



        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            playerRigidBody.velocity = Vector2.up * jumpSpeed;
        }


        if (isGrounded == false && (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Horizontal") > 0))
        {

            playerAnim.SetBool("isWalking", false);
            isMoving = true;

        }
        if (Input.GetKey(KeyCode.C) && Time.time > nextFire && !isMoving)
        {
            //Debug.Log("Aqui dispara: " + isMoving);
            nextFire = Time.time + fireRate;
            fireRollo();






        }

        if (Input.GetKey(KeyCode.X) && Time.time > nextFire && activateTlacuaches == true)
        {

            if (countTlacuachesRabia < numTlacuachesRabia)
            {
                nextFire = Time.time + fireRate;
                fireTlacuacheRabia();
                countTlacuachesRabia++;

            }
        }

        if (Input.GetKey(KeyCode.Z) && Time.time > nextFire && activateTlacuaches == true)
        {
            if (countTlacuachesAtaca < numTlacuachesAtaca)
            {
                nextFire = Time.time + fireRate;
                fireTlacuacheAtaca();
                countTlacuachesAtaca++;
            }

        }
    }

     
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lodo"))

        {
            //lodo.Play();
            Debug.Log("Lodo");
            this.speed = 3;
            if (GetComponent<PlayerMovement>().isGrounded)
            {




            }

        }
        else
        {
            this.speed = 15;
        }


        if (collision.gameObject.CompareTag("pltMov"))
        {
            this.transform.parent = collision.transform;

        }

        if (collision.gameObject.CompareTag("CheckPointBoss"))
        {
            activateTlacuaches = true;
         
        }

      


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pltMov"))
        {
            this.transform.parent = null;
        }
        if (collision.gameObject.CompareTag("Abismo"))
        {
            //Destroy(gameObject);
        }
    }



    public void fireRollo()
    {

        bulletPos = transform.position;

        if (isFlip == false)
        {
            bulletPos += new Vector2(1f, -0.437f);
            Instantiate(rolloRight, bulletPos, Quaternion.identity);
            soundBala.Play();

        }
        else if (isFlip == true)
        {
            bulletPos += new Vector2(-1f, -0.437f);
            Instantiate(rolloLeft, bulletPos, Quaternion.identity);
            soundBala.Play();
        }


    }

    public void fireTlacuacheRabia()
    {

        bulletPos = transform.position;

        if (isFlip == false)
        {
            bulletPos += new Vector2(1f, -0.2f);
            Instantiate(tlacuacheRabia, bulletPos, Quaternion.identity);
        }


    }

    public void fireTlacuacheAtaca()
    {

        bulletPos = transform.position;

        if (isFlip == false)
        {
            bulletPos += new Vector2(1f, -0.2f);
            Instantiate(tlacuacheAtaca, bulletPos, Quaternion.identity);
        }


    }



    void movePlayerHit()

    {

        Vector3 temp = new Vector3(-3.0f, 0, 0);

        if (Input.GetAxis("Horizontal") < 0)
        {
            this.transform.position += -(temp);

        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            this.transform.position += temp;
        }


    }

  



}