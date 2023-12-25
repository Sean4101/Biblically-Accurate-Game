using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MockUpLevelManager : MonoBehaviour
{

    [Header("References: ")]
    public LoreTextManager loreTextManager;
    public DialogueManager dialogueTextManager;
    
    [Header("Dialogue Lists: ")]
    public DialogLines introDialogueLines;
    public LoreTextLines prologueLines;

    private bool dialogueStarted = false;
    private bool loreStarted = false;
    // Start is called before the first frame update
    private void Awake()
    {
        loreTextManager = FindObjectOfType<LoreTextManager>();
        dialogueTextManager = FindObjectOfType<DialogueManager>();
    }
    
    void Start()
    {
        //disable dialogue box and lore box
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Intro started");
            if (!dialogueStarted)
            {   
                dialogueTextManager.StartLevelOneIntroDialogue(introDialogueLines);
                dialogueStarted = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("Prologue started");
            if (!loreStarted)
            {   
                loreTextManager.StartLoreDialogue(prologueLines);
                loreStarted = true;
            }
        }
    }
}
