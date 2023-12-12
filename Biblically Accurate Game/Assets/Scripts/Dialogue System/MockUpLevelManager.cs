using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MockUpLevelManager : MonoBehaviour
{

    [Header("References: ")]
    public LoreTextManager loreTextManager;
    public DialogueManager dialogueTextManager;
    public Image dialogueBox;
    public Image loreBox;
    
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
        dialogueBox.enabled = false;
        loreBox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Intro started");
            if (!dialogueStarted)
            {   
                dialogueBox.enabled = true;
                dialogueTextManager.StartDialogue(introDialogueLines);
                dialogueStarted = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("Prologue started");
            if (!loreStarted)
            {   
                loreBox.enabled = true;
                loreTextManager.StartLoreDialogue(prologueLines);
                loreStarted = true;
            }
        }
    }
}
