using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Reflection;

//this one is for prologue
public class LoreTextManager : MonoBehaviour
{
    [Header("References: ")]
    public TextMeshProUGUI textComponent;
    public Image loreBox;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public string loreName;
    //public LoreTextLines prologueLines;

    [Header("Settings: ")]
    public float prologueTextSpeed;
    public bool prologueEnd = false;
    public bool prologueOnGoing = false;
    public float alpha = 0;

    [Header("Background: ")]
    [SerializeField] private CanvasGroup canvasGroup;

    private int index;
    public bool _imageFadeOut = false;
    public bool _imageFadeIn = false;
    private LoreTextLines loreTextLines;

    private void Awake()
    {
        canvasGroup.alpha = 0;
        loreBox = GetComponent<Image>();
        loreBox.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        ClearDialogue();
        audioSource.clip = audioClip;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !prologueEnd && !_imageFadeIn)
        {
            if (isTypingFinished(index))
            {
                NextLine();
            }
            else
            {
                
                StopAllCoroutines();
                ShowWholeText(index);
            }
        }

        if (_imageFadeOut)
        {
            FadeOutBackground();
        }
        else if (_imageFadeIn )
        {
            FadeInBackground();
        }
        
    }

    public void StartLoreDialogue(LoreTextLines lines)
    {   
        if(lines.name != "prologueText")
        {
            _imageFadeIn = true;
            canvasGroup.alpha = 0;
            loreTextLines = lines;
            index = 0;
            prologueOnGoing = true;
            prologueEnd = false;
            loreBox.enabled = true;
            StartCoroutine(TypeLine());
        }
        else
        {
            _imageFadeIn = false;
            canvasGroup.alpha = 1;
            loreTextLines = lines;
            index = 0;
            prologueOnGoing = true;
            prologueEnd = false;
            loreBox.enabled = true;
            StartCoroutine(TypeLine());
        }
        
    }

    public void NextLine()
    {
        if (index < loreTextLines.loreLines.Count - 1)
        {
            index++;
            ClearDialogue();
            StartCoroutine(TypeLine());
        }
        else
        {
            //end of dialogue
            index = 0;
            ClearDialogue();
            prologueEnd = true;
            _imageFadeOut = true;
            
        }
    }
    IEnumerator TypeLine()
    {
        yield return new WaitUntil(() => !_imageFadeIn);

        foreach (char c in loreTextLines.loreLines[index].ToCharArray())
        {   
            PlaySound();
            textComponent.text += c;
            yield return new WaitForSeconds(prologueTextSpeed);
        }

    }

    bool isTypingFinished ( int lineIndexnInList )
    {
        if (textComponent.text == loreTextLines.loreLines[lineIndexnInList])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void ClearDialogue()
    {
        textComponent.text = string.Empty;
    }

    void ShowWholeText(int lineIndexndexInList)
    {
        textComponent.text = loreTextLines.loreLines[lineIndexndexInList];
    }

    public void FadeOutBackground()
    {
        canvasGroup.alpha -= Time.deltaTime;
        if (canvasGroup.alpha <= 0)
        {
            _imageFadeOut = false;
            gameObject.SetActive(false);
        }
        prologueOnGoing = false;
    }

    public void FadeInBackground()
    {
        canvasGroup.alpha += Time.deltaTime;
        if (canvasGroup.alpha >= 1)
        {
            _imageFadeIn = false;
        }
    }

    void PlaySound()
    {
        audioSource.time = 0f;
        audioSource.Play();
        
        if(audioSource.time == 0.032f)
        {
            audioSource.Stop();
        }
        
       
    }
}
