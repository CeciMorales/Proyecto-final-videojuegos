using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstToSecondScene : MonoBehaviour {
    private DialogueHolder dHolder;
    public GameObject puerta;


    // Use this for initialization
    void Start () {
        dHolder = FindObjectOfType<DialogueHolder>();
        puerta.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {

        if (dHolder.hadTalk)
        {
            Debug.Log("ABRETEE SESAMOOO");
            puerta.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 1);

        }
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {


            Debug.Log("Player");
            SceneManager.LoadScene("Nivel2");




        }
    }
    
    
}
