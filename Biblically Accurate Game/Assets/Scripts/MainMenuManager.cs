using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject chooseLavelPanel;

    private void Start()
    {
        // Show the main menu panel
        mainMenuPanel.SetActive(true);
        chooseLavelPanel.SetActive(false);
    }

    #region Main Menu Buttons

    public void StartGame()
    {
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
    }

    public void ChooseLevel()
    {
        // Show the choose level panel
        mainMenuPanel.SetActive(false);
        chooseLavelPanel.SetActive(true);
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }

    #endregion

    #region Choose Level Buttons

    public void BackToMainMenu()
    {
        // Show the main menu panel
        mainMenuPanel.SetActive(true);
        chooseLavelPanel.SetActive(false);
    }

    public void Level1()
    {
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
    }

    public void Level2()
    {
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level 2");
    }

    public void Level3() 
    {
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level 3");
    }

    #endregion
}
