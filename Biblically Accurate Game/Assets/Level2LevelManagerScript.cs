using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2LevelManagerScript : MonoBehaviour
{
    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void QuitToDeskTop()
    {
        Application.Quit();
    }
}
