using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_System : MonoBehaviour
{

    public  GameObject player;
    public Vector2 minCamPos, maxCamPos;
    public Vector2 minCamSub, maxCamSub;
   
    public float smoothTime;


    private Vector2 velocity;


    // Use this for initialization
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame

    void FixedUpdate()
    {

        float posX = Mathf.SmoothDamp(transform.position.x,
            player.transform.position.x, ref velocity.x, smoothTime*(0.15f));


        float posY = Mathf.SmoothDamp(transform.position.y,
           player.transform.position.y+5, ref velocity.y, smoothTime);

        Debug.Log(posY);

        if (posY > -14.5)
        {
         
            transform.position = new Vector3(
            Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
            transform.position.z);

        }
        else if (posY <= -14.5)
        {
            
            
            transform.position = new Vector3(
            Mathf.Clamp(posX, minCamSub.x, maxCamSub.x),
            Mathf.Clamp(posY, minCamSub.y, maxCamSub.y),
            transform.position.z);

        }


        if (posY > 400)
        {
      
            transform.position = new Vector3(
            Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posY, minCamSub.y+10, maxCamSub.y+10),
            transform.position.z);
        }

        

        

      

    }



}
