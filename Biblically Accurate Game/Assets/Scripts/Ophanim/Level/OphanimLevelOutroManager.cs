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
        destoyMinions();
        ClearProjectiles();
        stopAllCoroutineInBoss();
        StopBossAI();     

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
