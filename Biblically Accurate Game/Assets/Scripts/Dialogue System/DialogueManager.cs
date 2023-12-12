using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //combine introNameManager and introAvatarManager into this
    [Header("References: ")]
    public TextMeshProUGUI introDialogueMainText;
    public TextMeshProUGUI characterName;
    public Image avatarImage;
    
    [Header("Settings: ")]
    public float introTextSpeed;
    public bool introEnd = false;

    private DialogLines introDialogueLines;
    private int introIndex;

    // Start is called before the first frame update
    void Start()
    {
        ClearDialogue();
        avatarImage.enabled = false;
        //StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {   

        if (Input.GetKeyDown(KeyCode.V))
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

    public void StartDialogue(DialogLines lines)
    {
        introDialogueLines = lines;
        introIndex = 0;
        avatarImage.enabled = true;
        StartCoroutine(TypeLine());
    }

    public void NextLine()
    {
        if (introIndex < introDialogueLines.levelOneIntroLines.Count - 1)
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
    IEnumerator TypeLine()
    {
        avatarImage.sprite = introDialogueLines.levelOneIntroLines[introIndex].avatar;

        foreach (char c in introDialogueLines.levelOneIntroLines[introIndex].name.ToCharArray())
        {
            characterName.text += c;
            yield return new WaitForSeconds(introTextSpeed);
        }

        foreach (char c in introDialogueLines.levelOneIntroLines[introIndex].line.ToCharArray())
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
        if (introDialogueMainText.text == introDialogueLines.levelOneIntroLines[lineIndexInList].line && characterName.text == introDialogueLines.levelOneIntroLines[lineIndexInList].name)
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
        introDialogueMainText.text = introDialogueLines.levelOneIntroLines[lineIndexndexInList].line;
        characterName.text = introDialogueLines.levelOneIntroLines[lineIndexndexInList].name;
    }

}
