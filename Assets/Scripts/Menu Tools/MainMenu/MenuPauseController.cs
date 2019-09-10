using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuPauseController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settings;
    public SceneLoader sceneLoader;

    [SerializeField]
    private Button resumeButton, settingsButton, exitButton;

    public Player player;

    private bool isEnabled = false;
    private bool inSettings = false;

    private void Start()
    {
        player = ReInput.players.GetPlayer(1);
    }

    private void Update()
    {
        if (!isEnabled)
        {
            if (player.GetButtonDown("Start") || player.GetButtonDown("Back"))
            {
                Pause();
            }
            return;
        }

        if (inSettings)
        {
            if (player.GetButtonDown("B") || player.GetButtonDown("Back"))
            {
                inSettings = false;
                pauseMenu.SetActive(true);
            }
            else if (!settings.activeInHierarchy)
            {
                inSettings = false;
                pauseMenu.SetActive(true);
            }
            return;
        }

        if (player.GetButtonDown("A"))
        {
            if (EventSystem.current.currentSelectedGameObject == resumeButton.gameObject)
            {
                Resume();
            }
            else if (EventSystem.current.currentSelectedGameObject == settingsButton.gameObject)
            {
                Settings();
            }
            else if (EventSystem.current.currentSelectedGameObject == exitButton.gameObject)
            {
                Exit();
            }
            else
            {
                resumeButton.Select();
            }
        }

        if (player.GetButtonDown("Up"))
        {
            if (EventSystem.current.currentSelectedGameObject == resumeButton.gameObject)
            {
                exitButton.Select();
            }
            else if (EventSystem.current.currentSelectedGameObject == settingsButton.gameObject)
            {
                resumeButton.Select();
            }
            else
            {
                settingsButton.Select();
            }
        }

        if (player.GetButtonDown("Down"))
        {
            if (EventSystem.current.currentSelectedGameObject == resumeButton.gameObject)
            {
                settingsButton.Select();
            }
            else if (EventSystem.current.currentSelectedGameObject == settingsButton.gameObject)
            {
                exitButton.Select();
            }
            else
            {
                resumeButton.Select();
            }
        }

        if (player.GetButtonDown("B") || player.GetButtonDown("Back"))
        {
            Resume();
        }
    }

    public void Pause()
    {
        isEnabled = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    

    public void Resume()
    {
        isEnabled = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Settings()
    {
        pauseMenu.SetActive(false);
        settings.SetActive(true);
        inSettings = true;

    }

    public void Exit()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        sceneLoader.LoadSceneByIndex(1);
    }
}
