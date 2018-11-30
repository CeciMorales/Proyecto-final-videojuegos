using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 25;
    bool hasCoolDown = false;
    public double timeLeft =1;
    public double interval = 0.3;
    bool playerHit = false;
    int counterCoins;
    public PlayerMovement movementInstance;
  
    public void Start()
    {
        movementInstance.canMove = true;
    }

    public void Update()

    {
       
 

        //ve si no lo han golpeado
        returnPlayerHit();




    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
         
            if (collision.transform.position.y+2 > transform.position.y)
            {
                colorPlayerHit();
                movePlayerHit();
                movementInstance.canMove = false;
            }

        }

        if (collision.gameObject.CompareTag("Picos"))
        {
            colorPlayerHit();

        }

        if (collision.gameObject.CompareTag("Colmillo"))
        {
            colorPlayerHit();
            movePlayerHit();
            movementInstance.canMove = false;
        }
    }

    void movePlayerHit()

    {

        Vector3 temp = new Vector3(-3.0f, 0, 0);

        if (Input.GetAxis("Horizontal") < 0)
        {
            this.transform.position += -(temp);

        }else if (Input.GetAxis("Horizontal") > 0)
        {
            this.transform.position += temp;
        }
        
        
    }



    void colorPlayerHit()
    {
        if (GetComponent<SpriteRenderer>().color == new Color32(255, 255, 255, 255))
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 190, 210, 255);
            playerHit = true;
            Debug.Log(playerHit + " color, player heatlh");
        }
      


    }

    void returnPlayerHit()
    {
        if (playerHit)
        {

            timeLeft -= Time.deltaTime;
            if (timeLeft < 0 && GetComponent<SpriteRenderer>().color == new Color32(255, 190, 210, 255))
            {
                playerHit = false;
                movementInstance.canMove = true;
                GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

            }
        }
        else
        {
            timeLeft = 1;

        }

    }
    




    void SubstractHealth()
    {
        if (!hasCoolDown)
        {
            if (health > 0)
            {
                health--;
   
                hasCoolDown = true;
                StartCoroutine(CoolDown());

            }

            if (health <= 0)
            {
                //changeScene.ChangeSceneTo("SampleScene");
            }
            
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        hasCoolDown = false;
        StopCoroutine(CoolDown());
    }

   

    
    }


