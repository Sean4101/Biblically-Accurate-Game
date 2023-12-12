using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //combine introNameManager and introAvatarManager into this

    public TextMeshProUGUI introDialogueMainText;
    public TextMeshProUGUI characterName;
    public DialogLines introDialogueLines;
    public Image avatarImage;

    public float introTextSpeed;
    public bool introEnd = false;

    private int introIndex;

    // Start is called before the first frame update
    void Start()
    {
        ClearDialogue();
        //StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {   

        if (Input.GetKeyDown(KeyCode.P))
        {   
            //check whther the text finished typing, if so, go to next line, else stop typing and show full text
            if (introDialogueMainText.text == introDialogueLines.lines[introIndex].line && characterName.text == introDialogueLines.lines[introIndex].name )
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                introDialogueMainText.text = introDialogueLines.lines[introIndex].line;
                characterName.text = introDialogueLines.lines[introIndex].name;
            }
        }
    }

    public void StartDialogue()
    {
        introIndex = 0;
        StartCoroutine(TypeLine());
    }

    public void NextLine()
    {
        if (introIndex < introDialogueLines.lines.Count - 1)
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
        avatarImage.sprite = introDialogueLines.lines[introIndex].avatar;

        foreach (char c in introDialogueLines.lines[introIndex].name.ToCharArray())
        {
            characterName.text += c;
            yield return new WaitForSeconds(introTextSpeed);
        }

        foreach (char c in introDialogueLines.lines[introIndex].line.ToCharArray())
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
    }

}
