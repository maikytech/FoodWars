using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string levelToLoad;

    public void GoToMainScene()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void GoToExit()
    {
        Application.Quit();
    }
}
