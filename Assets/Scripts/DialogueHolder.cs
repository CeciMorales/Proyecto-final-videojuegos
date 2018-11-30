using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    public string dialogue;
    private DialogueManager dMan;
    public bool hadTalk;

    public string[] dialogueLines;


	// Use this for initialization
	void Start () {
        dMan = FindObjectOfType<DialogueManager>();
        hadTalk = false;
        Debug.Log("INICIOO"+hadTalk);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("HOLAAA" + hadTalk);


            if (hadTalk == false)
            {

                Debug.Log("ENTRO A METODO");
             
                
                if (!dMan.dialogueActive)
                {
                    //deactivated
                    dMan.setDialogueLines(dialogueLines);
                    dMan.currentLine = 0;
                    dMan.showDialogue();
                    hadTalk = true;
                }

                

               
                
            }
               
            
            

        }
    }
}
