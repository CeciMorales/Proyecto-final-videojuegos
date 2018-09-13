using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coin : MonoBehaviour
{
    public static int collectableQuantity = 0;
    Text collectableText;

    ParticleSystem collectablePart;
    AudioSource collectableAudio;
    // Use this for initialization
    void Start()
    {
        collectableText = GameObject.Find("Collectable").GetComponent<Text>();
        collectablePart = GameObject.Find("CollectableParticle").GetComponent<ParticleSystem>();
        //collectableAudio = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            collectablePart.transform.position = transform.position; //darle la posicion del coleccionable actual
            collectablePart.Play();//Salen las particulas
            //collectableAudio.Play(); //Suene el sonido
            gameObject.SetActive(false); //desaparece el item
            collectableQuantity++;
            collectableText.text = collectableQuantity.ToString(); //actualizar el texto
        }
    }
}
