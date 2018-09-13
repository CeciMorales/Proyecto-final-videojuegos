using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public GameObject BulletEmissor;

    public GameObject Bala;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Shoot", 0, 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Shoot()
    {
        Instantiate(Bala, BulletEmissor.transform.position, Quaternion.identity);
    }
}
