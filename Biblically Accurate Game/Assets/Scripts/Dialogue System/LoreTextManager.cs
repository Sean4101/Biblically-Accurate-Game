using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//this one is for prologue
public class LoreTextManager : MonoBehaviour
{   
    public TextMeshProUGUI textComponent;
    public LoreTextLines prologueLines;
    public float prologueTextSpeed;
    public bool prologueEnd = false;

    private int index;


    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            if(textComponent.text == prologueLines.lines[index])
            {
                NextLine();
            }
            else
            {   
                StopAllCoroutines();
                textComponent.text = prologueLines.lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    public void NextLine()
    {
        if (index < prologueLines.lines.Count - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {  
            //end of dialogue
            textComponent.text = string.Empty;

            //makes background fade out, but dk how to do that
            //gameObject.transform.parent.GetComponent<Animator>().SetTrigger("FadeOut");
            prologueEnd = true;
            gameObject.SetActive(false); 
        }
    }
    IEnumerator TypeLine()
    {
        foreach(char c in prologueLines.lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(prologueTextSpeed);
        }
    }
}
