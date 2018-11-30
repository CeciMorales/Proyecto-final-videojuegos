using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroToFirstScene : MonoBehaviour {

    float timeLeft = 30.0f;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            SceneManager.LoadScene("Nivel1");
            //CAMBIAR ESTE SCRIPT A FLAVIO BASIC MOOOV  
        }
		
	}
}
