using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    Image healthBar;
    float maxHealth = 100f;
    public static float health;


	// Use this for initialization
	void Start () {
        healthBar = GetComponent<Image>();
        health = maxHealth;
        //al inicio esta con toda la vida completa
		
	}
	
	// Update is called once per frame
	void Update () {

        healthBar.fillAmount = health / maxHealth;
		
	}
}
