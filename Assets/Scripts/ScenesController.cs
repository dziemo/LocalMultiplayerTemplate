using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    private void Start()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == "InputScene")
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("InputScene"));
        }
    }

    public void LoadInputScene ()
    {
        SceneManager.LoadScene("InputScene", LoadSceneMode.Additive);
    }

    public void LoadGameScene ()
    {
        SceneManager.UnloadSceneAsync("Menu");
        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
    }

    public void LoadMenuScene()
    {
        SceneManager.UnloadSceneAsync("Game");
        SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Additive);
    }
}
