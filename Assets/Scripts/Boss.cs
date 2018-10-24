using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public GameObject BulletEmissor;
    public int health = 10;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tlacuache"))
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
