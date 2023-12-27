using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OphanimLevelOutroManager : MonoBehaviour
{
    public GameObject victoryPlaceholderPanel;
    public GameObject defeatPlaceholderPanel;
    public GameObject victoryNextLevelPanel;
    public GameObject defeatRetryPanel;

    [Header("References")]
    public GameObject dialogueBox;
    public GameObject loreBox;
    public DialogueManager dialogueManager;
    public LoreTextManager loreTextManager;
    public DialogLines victoryDialogueLines;
    public OphanimLevelIntroManager levelTwoIntro;

    //called by OphanimLevelManager

    private void Start()
    {
       
    }
    public void StartVictoryOutro()
    {   
        destoyMinions();
        ClearProjectiles();
        stopAllCoroutineInBoss();
        StopBossAI();     

        dialogueBox.SetActive(true);
        dialogueManager.StartDialogue(victoryDialogueLines);
        
        StartCoroutine(PlayVictoryOutro());
    }

    public void StartDefeatOutro()
    {   
        destoyMinions();
        ClearProjectiles();
        stopAllCoroutineInBoss();
        StopBossAI();
        
        StartCoroutine(PlayDefeatOutro());
    }

    private IEnumerator PlayVictoryOutro()
    {
        yield return new WaitUntil(() => dialogueManager.introEnd);
        yield return new WaitForSeconds(1f);
        //Ik it's stupid to right shit here but idk whether we will have a level 2 or not
        loreBox.SetActive(true);
        levelTwoIntro.StartLevelTwoIntro();

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

    public void ClearProjectiles()
    {   
        Debug.Log("Clearing projectiles");
        //destoy all gameobject with tag hostileprojectiles and friendlyprojectile
        GameObject[] hostileProjectiles = GameObject.FindGameObjectsWithTag("HostileProjectile");
        GameObject[] friendlyProjectiles = GameObject.FindGameObjectsWithTag("FriendlyProjectile");
        foreach (GameObject hostileProjectile in hostileProjectiles)
        {   
            Debug.Log("Destroying hostile projectile");
            Destroy(hostileProjectile);
        }
        foreach (GameObject friendlyProjectile in friendlyProjectiles)
        {   
            Debug.Log("Destroying friendly projectile");
            Destroy(friendlyProjectile);
        }
    }

    public void StopBossAI()
    {
        GameObject boss = GameObject.Find("Disco Angel Ophanimim");
        
        boss.GetComponent<OphanimAI>().enabled = false;
       
    }

    public void stopAllCoroutineInBoss()
    {
        GameObject boss = GameObject.Find("Disco Angel Ophanimim");
        boss.GetComponent<OphanimAI>().StopAllCoroutines();
    }

    public void destoyMinions()
    {
        //find all enemies with tag enemy but except boss since boss got the same tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy.name != "Disco Angel Ophanimim")
            {   
                Debug.Log("Destroying enemy");
                Destroy(enemy);
            }
        }
    }

}
