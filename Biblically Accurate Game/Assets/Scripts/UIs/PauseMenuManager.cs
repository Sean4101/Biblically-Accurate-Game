using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuPanel;

    void Start()
    {
        // Hide the pause menu panel
        pauseMenuPanel.SetActive(false);
    }

    void Update()
    {
        // If the player presses the escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the pause menu is not active
            if (!pauseMenuPanel.activeSelf)
            {
                // Pause the game
                Time.timeScale = 0;
                // Show the pause menu panel
                pauseMenuPanel.SetActive(true);
            }
            else
            {
                // Unpause the game
                Time.timeScale = 1;
                // Hide the pause menu panel
                pauseMenuPanel.SetActive(false);
            }
        }
    }

    #region Pause Menu Buttons

    public void ResumeGame()
    {
        // Unpause the game
        Time.timeScale = 1;
        // Hide the pause menu panel
        pauseMenuPanel.SetActive(false);
    }

    public void RestartGame()
    {
        // Unpause the game
        Time.timeScale = 1;
        // Reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        // Unpause the game
        Time.timeScale = 1;
        // Load the main menu scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }

    #endregion
}
