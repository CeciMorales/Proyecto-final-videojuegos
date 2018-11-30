using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour {

    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    public Image healthBar;
    public Image flabio;
    //public GameObject FlavioLleno;
    //public GameObject FlavioMedio;
    //public GameObject FlavioMuerto;

    //DIE
    public Sprite flavioDead;


    public GameObject flavioMuerte;
     
    public bool isDead;






    // Use this for initialization
    void Start () {
        health = maxHealth;
        flabio = GameObject.Find("ImagenFlavio").GetComponent<Image>();
        isDead = false;






    }

    void Update () {
        
        if (health <= maxHealth && health >10)
        {
            flabio.sprite = Resources.Load<Sprite>("Sprites/lifeBar1");

        }
        if (health <= 10 && health > 1)
        {

            flabio.sprite = Resources.Load<Sprite>("Sprites/lifeBar2");
        }
        if (health <= 1)
        {

            flabio.sprite = Resources.Load<Sprite>("Sprites/lifeBar3");
        }

        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(health);
        if(collision.gameObject.CompareTag("Enemy"))
        {
            health = health - 1;
            healthBar.fillAmount = (1 / maxHealth) * health;
        }

        if (collision.gameObject.CompareTag("OlmecaRoja"))
        {
            health = health - 2;
            healthBar.fillAmount = (1 / maxHealth) * health;
        }
        if (collision.gameObject.CompareTag("Picos"))
        {

            health = health - 2;
            healthBar.fillAmount = (1 / maxHealth) * health;
        }
        if (collision.gameObject.CompareTag("NubeRoja") )
        {

            health = health - 1;
            healthBar.fillAmount = (1 / maxHealth) * health;
        }

        if (collision.gameObject.CompareTag("Colmillo") || collision.gameObject.CompareTag("RayoAmarillo"))
        {

            health = health - 1;
            healthBar.fillAmount = (1 / maxHealth) * health;
        }

        if (health<= 0 || collision.gameObject.CompareTag("Abismo"))
        {
            isDead = true;
           
            Instantiate(flavioMuerte, transform.position, Quaternion.identity);

            //gameObject.GetComponent<SpriteRenderer>().color =
            new Color32(1, 1, 1, 0);
            //spriteR.sprite = flavioDead;
// Destroy(gameObject);
            GetComponent<SpriteRenderer>().sprite = flavioDead;
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

    
}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("particula") || collision.gameObject.CompareTag("RayoAzul"))
        {
           
            health = health - 1;
            healthBar.fillAmount = (1 / maxHealth) * health;
        }
        if (collision.gameObject.CompareTag("Jade"))
        {
            
            health = health + 5;
            healthBar.fillAmount = (1 / maxHealth) * health;
            
        }
    }


}
