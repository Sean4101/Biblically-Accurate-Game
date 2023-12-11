using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockUpLevelManager : MonoBehaviour
{   
    public DialogManager dialogManager;
    public IntroManager introManager;
    private bool dialoguesStarted = false;
    // Start is called before the first frame update
    private void Awake()
    {
        dialogManager = FindObjectOfType<DialogManager>();
        introManager = FindObjectOfType<IntroManager>();

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
            {   //Debug.Log("Intro started");
                introManager.StartIntroDialogue();
                dialoguesStarted = true;
            }
        }
    }
}
