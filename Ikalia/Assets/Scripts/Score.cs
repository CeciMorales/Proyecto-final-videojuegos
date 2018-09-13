using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //reinicia
using UnityEngine.UI;


public class Score : MonoBehaviour
{

    private float timeLeft = 120;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;



    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame

    void Update()
    {
        //Debug.Log(timeLeft);
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = (" "+(int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        if (timeLeft < 0.1f) //reinicia el tiempo 
        {
            SceneManager.LoadScene("SampleScene");


        }

    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name == "EndLevel")
        {
            //Debug.Log("Touched the end of level");
            CountScore();

        }

        if (trig.gameObject.name == "coin")
        {
            playerScore += 10;
            Debug.Log(playerScore);
            Destroy(trig.gameObject);
        }

        if (trig.gameObject.name == "Enemy")
        {
            playerScore += 2;
            Debug.Log(playerScore);

        }

    }

    void CountScore()
    {
        playerScore = playerScore + (int)(timeLeft * 10);
        Debug.Log(playerScore);

    }


}
