using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OphanimLevelIntroManager : MonoBehaviour
{
    public bool introComplete = false;
    private bool dialogueStarted = false;
    private bool loreStarted = false;
    private bool loreFinished = false;
    [Header("References")]
    public LoreTextManager loreTextManager;
    public DialogueManager dialogueTextManager;
    public LoreTextLines prologueLines;
    public LoreTextLines act2LoreLines;
    public DialogLines introDialogueLines;

   
    public void StartIntro()
    {
        StartCoroutine(PlayLevelOneIntro());
    }
    
    public void StartLevelTwoIntro()
    {
        StartCoroutine(PlayLevelTwoIntro());
    }
    private IEnumerator PlayLevelOneIntro()
    {
        loreTextManager.StartLoreDialogue(prologueLines);
        yield return new WaitUntil(() => loreTextManager.loreEnd);
        dialogueTextManager.StartDialogue(introDialogueLines);
        yield return new WaitUntil(() => dialogueTextManager.introEnd);
        introComplete = true;
    }
    
    //because we prob won't have level two so Imma write stuff here first
    private IEnumerator PlayLevelTwoIntro()
    {   
        introComplete = false;
        loreTextManager.StartLoreDialogue(act2LoreLines);
        yield return new WaitUntil(() => loreTextManager.loreEnd);
        introComplete = true;
    }



}
