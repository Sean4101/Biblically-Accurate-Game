using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{   
    LoreTextManager loreTextManager;
    //combine introNameManager and introAvatarManager into this
    [Header("References: ")]
    public TextMeshProUGUI introDialogueMainText;
    public TextMeshProUGUI characterName;
    public Image avatarImage;
    public Image dialogueBox;

    [Header("Settings: ")]
    public float introTextSpeed;
    public bool introEnd = false;

    private DialogLines dialogueLines;
    private int introIndex;

    private void Awake()
    {
        dialogueBox = GetComponent<Image>();
        loreTextManager = FindObjectOfType<LoreTextManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ClearDialogue();
        dialogueBox.enabled = false;
        avatarImage.enabled = false;
        //StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {   

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!loreTextManager.prologueOnGoing)
            {
                //check whther the text finished typing, if so, go to next line, else stop typing and show full text
                if ( IsTypingFinished(introIndex) )
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    PresentWholeText(introIndex);
                }
            }
           
        }
    }

    public void StartDialogue(DialogLines lines)
    {
        introEnd = false;
        dialogueBox.enabled = true;
        dialogueLines = lines;
        introIndex = 0;
        avatarImage.enabled = true;
        StartCoroutine(TypeLine());
    }

    public void NextLine()
    {
        if (introIndex < dialogueLines.dialogueLines.Count - 1)
        {
            introIndex++;
            ClearDialogue();
            StartCoroutine(TypeLine());
        }
        else
        {
            //end of dialogue
            ClearDialogue();
            introEnd = true;
            gameObject.SetActive(false);
        }
    }
    IEnumerator TypeLine( )
    {
        avatarImage.sprite = dialogueLines.dialogueLines[introIndex].avatar;

        foreach (char c in dialogueLines.dialogueLines[introIndex].name.ToCharArray())
        {
            characterName.text += c;
            yield return new WaitForSeconds(introTextSpeed);
        }

        foreach (char c in dialogueLines.dialogueLines[introIndex].line.ToCharArray())
        {
            introDialogueMainText.text += c;
            yield return new WaitForSeconds(introTextSpeed);
        }
        
    }

    void ClearDialogue()
    {
        introDialogueMainText.text = string.Empty;
        characterName.text = string.Empty;
        avatarImage.sprite = null;
        //make sure the avatar is not visible
    }

    bool IsTypingFinished(int lineIndexInList)
    {
        if (introDialogueMainText.text == dialogueLines.dialogueLines[lineIndexInList].line && characterName.text == dialogueLines.dialogueLines[lineIndexInList].name)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void PresentWholeText(int lineIndexndexInList)
    {
        introDialogueMainText.text = dialogueLines.dialogueLines[lineIndexndexInList].line;
        characterName.text = dialogueLines.dialogueLines[lineIndexndexInList].name;
    }

}
