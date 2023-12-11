using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    public TextMeshProUGUI component;
    public TextMeshProUGUI avatarComponent;
    public DialogLines introLines;
    public Image protag;
    public Image angel;
    public Avatar avatar;
    public DialogLines avatarList;

    public float introTextSpeed;
    public bool introEnd = false;

    private int introIndex;
    private int avatarIndex;    

    // Start is called before the first frame update
    void Start()
    {
        component.text = string.Empty;
        avatar = GetComponent<Avatar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (component.text == introLines.lines[introIndex])
            {
                NextIntroLine();
                NextAvatarCheck();
            }
            else
            {
                StopAllCoroutines();
                component.text = introLines.lines[introIndex];
            }
        }
    }

    public void StartIntroDialogue()
    {
        introIndex = 0;
        StartCoroutine(TypeLine());
    }

    public void NextIntroLine()
    {
        if (introIndex < introLines.lines.Count - 1)
        {
            introIndex++;
            component.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            //end of dialogue
            component.text = string.Empty;

            //makes background fade out, but dk how to do that
            //gameObject.transform.parent.GetComponent<Animator>().SetTrigger("FadeOut");
            introEnd = true;
            gameObject.SetActive(false);
        }
    }

    //unfinished
    public void NextAvatarCheck()
    {
        if(avatarIndex < avatarList.lines.Count - 1)
        {
            avatarIndex++;
        }
        else
        {
            avatarComponent.text = string.Empty;
        }
    }
    IEnumerator TypeLine()
    {
        foreach (char c in introLines.lines[introIndex].ToCharArray())
        {
            component.text += c;
            yield return new WaitForSeconds(introTextSpeed);
        }
    }

    IEnumerable AvatarSwitch()
    {
        foreach (char c in avatarList.lines[avatarIndex].ToCharArray())
        {   
            //to be changed
            avatarComponent.text += c;
            yield return new WaitForSeconds(introTextSpeed);
        }
    }
}
