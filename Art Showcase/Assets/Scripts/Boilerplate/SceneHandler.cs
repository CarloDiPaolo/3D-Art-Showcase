using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public static void LoadCredits()
    {
        SceneManager.LoadScene(2);
    }

    public static void LoadIntro()
    {
        SceneManager.LoadScene(3);
    }

    public static void LoadLevelWithIndex(int i)
    {
        SceneManager.LoadScene(i);
    }

    public static void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public static void LoadNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index+1);
    }
}
