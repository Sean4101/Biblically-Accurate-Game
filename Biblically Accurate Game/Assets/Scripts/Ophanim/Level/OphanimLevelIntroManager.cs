using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OphanimLevelIntroManager : MonoBehaviour
{
    public bool introComplete = false;

    [Header("References")]
    public GameObject introPlaceholderPanel;

    public void StartIntro()
    {
        InitializeIntro();
        StartCoroutine(PlayIntro());
    }

    private void InitializeIntro()
    {
        introPlaceholderPanel.SetActive(true);
    }

    private IEnumerator PlayIntro()
    {
        yield return new WaitForSeconds(3f);
        introPlaceholderPanel.SetActive(false);
        Debug.Log("Intro complete");
        introComplete = true;
    }
}
