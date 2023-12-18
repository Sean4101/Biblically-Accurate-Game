using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OphanimLevelIntroManager : MonoBehaviour
{
    public bool introComplete = false;
    private bool dialogueStarted = false;
    private bool loreStarted = false;
    [Header("References")]
    public LoreTextManager loreTextManager;
    public DialogueManager dialogueTextManager;
    public LoreTextLines prologueLines;
    public DialogLines introDialogueLines;

    public void StartIntro()
    {
        StartCoroutine(PlayIntro());
    }
   
    private IEnumerator PlayIntro()
    {
        loreTextManager.StartLoreDialogue(prologueLines);
        yield return new WaitUntil(() => loreTextManager.prologueEnd);
        dialogueTextManager.StartDialogue(introDialogueLines);
        yield return new WaitUntil(() => dialogueTextManager.introEnd);
        introComplete = true;
    }
  
   
    
}
