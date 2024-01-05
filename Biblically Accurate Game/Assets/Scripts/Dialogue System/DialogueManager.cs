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
    public AudioSource audioSource;
    public AudioClip audioClip;
    public BossStatus bossStatus;
    string introName;
    [Header("Settings: ")]
    public float introTextSpeed;
    public bool introEnd = false;

    private DialogLines dialogueLines;
    private int introIndex;
    public CameraEffects cameraEffects;

    private void Awake()
    {
        dialogueBox = GetComponent<Image>();
        loreTextManager = FindObjectOfType<LoreTextManager>();
        cameraEffects = FindObjectOfType<CameraEffects>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ClearDialogue();
        dialogueBox.enabled = false;
        avatarImage.enabled = false;
        audioSource.clip = audioClip;
        bossStatus = FindObjectOfType<BossStatus>();
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
        introName = lines.name;
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
            if(introName == "VictoryDialogue")
            {
                if(introIndex == 25)
                {   
                    Debug.Log("Shrink");
                    bossStatus.Shrink();
                }
            }
            else if(introName == "IntroDialogue")
            {
                if(introIndex == 12)
                {
                   cameraEffects.Shake(2.5f);
                }
            }
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
            PlaySound();
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

    void PlaySound()
    {
        audioSource.time = 0f;
        audioSource.Play();

        if (audioSource.time == 0.03f)
        {
            audioSource.Stop();
        }


    }

}
