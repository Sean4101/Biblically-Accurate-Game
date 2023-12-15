using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//this one is for prologue
public class LoreTextManager : MonoBehaviour
{
    [Header("References: ")]
    public TextMeshProUGUI textComponent;
    public Image loreBox;
    //public LoreTextLines prologueLines;

    [Header("Settings: ")]
    public float prologueTextSpeed;
    public bool prologueEnd = false;

    [Header("Background: ")]
    [SerializeField] private CanvasGroup canvasGroup;

    private int index;
    private bool _imageFadeOut = false;
    private LoreTextLines loreTextLines;

    private void Awake()
    {
        loreBox = GetComponent<Image>();
        loreBox.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        ClearDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
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

    }

    public void StartLoreDialogue(LoreTextLines lines)
    {
        prologueEnd = false;
        loreBox.enabled = true;
        loreTextLines = lines;
        index = 0;
        StartCoroutine(TypeLine());
    }

    public void NextLine()
    {
        if (index < loreTextLines.prologueLines.Count - 1)
        {
            index++;
            ClearDialogue();
            StartCoroutine(TypeLine());
        }
        else
        {
            //end of dialogue
            ClearDialogue();
            prologueEnd = true;
            _imageFadeOut = true;
            
        }
    }
    IEnumerator TypeLine()
    {
        foreach(char c in loreTextLines.prologueLines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(prologueTextSpeed);
        }
    }

    bool isTypingFinished ( int lineIndexndexInList )
    {
        if (textComponent.text == loreTextLines.prologueLines[lineIndexndexInList])
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
        textComponent.text = loreTextLines.prologueLines[lineIndexndexInList];
    }

    public void FadeOutBackground()
    {
        canvasGroup.alpha -= Time.deltaTime;
        if (canvasGroup.alpha <= 0)
        {
            _imageFadeOut = false;
            gameObject.SetActive(false);
        }
    }
    

}
