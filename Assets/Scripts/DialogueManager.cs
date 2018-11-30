using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;
    public GameObject dMentor;
    public bool dialogueActive;
    private string[] dialogueLines;
    public int currentLine;
  
   
    public void setDialogueLines(string [] dialogueLines)
    {
        this.dialogueLines = dialogueLines;
    }
	// Use this for initialization
	void Start () {
        currentLine = 0;
        dialogueLines = new string[1];
        dialogueActive = false;
  

       
		
	}

    // Update is called once per frame
    void Update()
    {

        if (dialogueActive && Input.GetKeyUp(KeyCode.X))
        {

            currentLine++;
            
        }

   
        if (currentLine >= dialogueLines.Length)
        {
            dMentor.SetActive(false);
            dialogueActive = false;

            currentLine = 0;
        }

        dText.text = dialogueLines[currentLine];
   
        

    }

    public void showBox(string dialogue)
    {
        dialogueActive = true;
        dMentor.SetActive(true);
        dText.text = dialogue;

    }

    public void showDialogue()
    {

        dialogueActive = true;
        dMentor.SetActive(true);
    }
}
