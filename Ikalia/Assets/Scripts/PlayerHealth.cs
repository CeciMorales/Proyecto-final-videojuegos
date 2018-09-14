using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public int health = 3;
    public Image[] hearts;
    bool hasCoolDown = false;


    //public SceneChanger changeScene;
    // Use this for initialization

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Picos"))
        {
            if (GetComponent<PlayerMovement>().isGrounded)
            {
                SubstractHealth();
            }
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
            EmptyHearts();
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        hasCoolDown = false;
        StopCoroutine(CoolDown());
    }

    void EmptyHearts()
    {
        for( int i = 0; i< hearts.Length; i++)
        {
            if(health-1 < i)
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }
}
