using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OphanimLevelOutroManager : MonoBehaviour
{
    public GameObject victoryPlaceholderPanel;
    public GameObject defeatPlaceholderPanel;
    public GameObject victoryNextLevelPanel;
    public GameObject defeatRetryPanel;

    public void StartVictoryOutro()
    {
        StartCoroutine(PlayVictoryOutro());
    }

    public void StartDefeatOutro()
    {
        StartCoroutine(PlayDefeatOutro());
    }

    private IEnumerator PlayVictoryOutro()
    {
        victoryPlaceholderPanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        victoryPlaceholderPanel.SetActive(false);
        victoryNextLevelPanel.SetActive(true);
    }

    private IEnumerator PlayDefeatOutro()
    {
        defeatPlaceholderPanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        defeatPlaceholderPanel.SetActive(false);
        defeatRetryPanel.SetActive(true);
    }

    public void NextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RetryLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
