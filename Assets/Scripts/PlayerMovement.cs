using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    public Rigidbody2D playerRigidBody;
    public float speed = 15f;
    public float jumpSpeed = 50;

    private float moveInput; //detect wheather or not is left or right
    public Animator playerAnim;
    


    //jump
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public static bool isFlip;

    private int extraJumps;
    public int extraJumpsvalue;

    //animation-fall
    // private bool justJumped;

    //BULLET
    public GameObject camara;
    public Transform throwPointRight;
    //public Transform throwPointLeft;

    //MONEDAS
    public int counterCoins;
    public Image imagenMonedas;




    // Use this for initialization
    void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsvalue;
        isFlip = false;
        imagenMonedas = GameObject.Find("Numeros").GetComponent<Image>();
        //justJumped = false;
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
            
            isFlip = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            
            playerAnim.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = false;
            isFlip = false;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GetComponent<AudioSource>().Play();
            //playerAnim.SetBool("isJumping", true);
            playerAnim.SetTrigger("IsJumping");
            playerRigidBody.AddForce(Vector2.up * jumpSpeed);
            //justJumped = true;
            isGrounded = false;
            //playerAnim.SetTrigger("Jump");

        }

       /* if (Input.GetKeyDown(KeyCode.DownArrow) && isFlip == false)
        {
            GameObject camaraClone = (GameObject)Instantiate(camara, throwPointRight.position, throwPointRight.rotation);

            camaraClone.transform.localScale = -transform.localScale;

            Instantiate(camara, throwPointRight.position, throwPointRight.rotation);
           

        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && isFlip == true)    
        {

            GameObject camaraClone = (GameObject)Instantiate(camara, throwPointLeft.position, throwPointLeft.rotation);

            camaraClone.transform.localScale = -transform.localScale;

            Instantiate(camara, throwPointLeft.position, throwPointLeft.rotation);

        }*/

        
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



        }else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            playerRigidBody.velocity = Vector2.up * jumpSpeed;
        }

        
        if (isGrounded == false && (Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Horizontal") > 0))
        {
            
            playerAnim.SetBool("isWalking", false);

        }

        PlayingShooter();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lodo"))

        {

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
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pltMov"))
        {
            this.transform.parent = null;
        }
    }

    public void PlayingShooter()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
             Instantiate(camara, throwPointRight.position, Quaternion.identity);
            
        }
       


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            counterCoins++;
            if(counterCoins == 1)
            {
                imagenMonedas.sprite = Resources.Load<Sprite>("Sprites/1");
            }else if( counterCoins == 2)
            {
                imagenMonedas.sprite = Resources.Load<Sprite>("Sprites/2");
            }
            else if (counterCoins == 3)
            {
                imagenMonedas.sprite = Resources.Load<Sprite>("Sprites/3");
            }
            else if (counterCoins == 4)
            {
                imagenMonedas.sprite = Resources.Load<Sprite>("Sprites/4");
            }
            else if (counterCoins == 5)
            {
                imagenMonedas.sprite = Resources.Load<Sprite>("Sprites/5");

            }
            else if (counterCoins == 6)
            {
                imagenMonedas.sprite = Resources.Load<Sprite>("Sprites/6");
            }
            else if (counterCoins == 7)
            {
                imagenMonedas.sprite = Resources.Load<Sprite>("Sprites/7");
            }
            else if (counterCoins == 8)
            {
                imagenMonedas.sprite = Resources.Load<Sprite>("Sprites/8");
            }
            else if (counterCoins == 9)
            {
                imagenMonedas.sprite = Resources.Load<Sprite>("Sprites/9");
            }
        }
    }

}
