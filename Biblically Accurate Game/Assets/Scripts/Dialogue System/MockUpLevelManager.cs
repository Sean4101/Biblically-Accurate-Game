using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockUpLevelManager : MonoBehaviour
{   
    public LoreTextManager loreTextManager;
    public DialogueManager dialogueTextManager;

    private bool dialoguesStarted = false;
    // Start is called before the first frame update
    private void Awake()
    {
        loreTextManager = FindObjectOfType<LoreTextManager>();
        dialogueTextManager = FindObjectOfType<DialogueManager>();
       

        /*
        if(dialogManager.prologueEnd)
        {
            dialogManager.StartDialogue();
            dialoguesStarted = true;
        }
        */
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* Kept just in case, used to call the prologue
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!dialoguesStarted)
            {
                dialogManager.StartDialogue();
                dialoguesStarted = true;
            }
        }
        */

        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Intro started");
            if (!dialoguesStarted)
            {   
                dialogueTextManager.StartDialogue();
                //loreTextManager.StartDialogue();
                dialoguesStarted = true;
            }
        }
    }
}
