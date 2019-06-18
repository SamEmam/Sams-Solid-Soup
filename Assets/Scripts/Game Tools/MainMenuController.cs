using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

public class MainMenuController : MonoBehaviour
{
    SceneLoader sceneLoader;
    public Button playLocalButton;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        playLocalButton.Select();
    }

    public void PlayLocal()
    {
        sceneLoader.LoadSceneByIndex(1);
    }

    public void PlayOnline()
    {

    }

    public void Options()
    {
        sceneLoader.LoadSceneByName("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
